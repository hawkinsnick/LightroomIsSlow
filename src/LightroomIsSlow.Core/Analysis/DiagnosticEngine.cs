using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Analysis;

public sealed class DiagnosticEngine
{
    public IReadOnlyList<DiagnosticFinding> Evaluate(IReadOnlyList<TelemetrySample> samples)
    {
        if (samples.Count < 10) return [Insufficient("Too few samples for a defensible diagnosis.")];
        var findings = new List<DiagnosticFinding>();
        var validDisk = samples.Where(s => s.DiskReadLatencyMs.HasValue && s.DiskQueueDepth.HasValue).ToArray();
        if (validDisk.Length >= samples.Count / 2)
        {
            var pressured = validDisk.Count(s => s.DiskReadLatencyMs >= 20 && s.DiskQueueDepth >= 2);
            var cpuHeadroom = samples.Count(s => s.CpuSystemPercent is < 80);
            if (pressured >= validDisk.Length * .30 && cpuHeadroom >= samples.Count * .50)
                findings.Add(new("STORAGE_PRESSURE","Storage pressure observed","Elevated storage latency and queueing persisted while CPU headroom remained available.",FindingSeverity.High,FindingConfidence.High,
                    [$"Pressure samples: {pressured}/{validDisk.Length}",$"CPU-headroom samples: {cpuHeadroom}/{samples.Count}"],[],
                    ["Investigate the physical drive hosting the Lightroom catalog, previews, cache, and active originals before considering CPU upgrades."]));
        }

        var memoryPressure = samples.Count(s => s.MemoryAvailableMb is < 1024 && s.MemoryHardFaultsPerSecond is > 10);
        if (memoryPressure >= samples.Count * .20)
            findings.Add(new("MEMORY_PRESSURE","Memory pressure observed","Low available memory coincided with sustained hard faults.",FindingSeverity.High,FindingConfidence.High,
                [$"Pressure samples: {memoryPressure}/{samples.Count}"],[],["Reduce concurrent memory demand or evaluate additional RAM."]));

        var cpuSat = samples.Count(s => s.CpuSystemPercent is >= 90);
        if (cpuSat >= samples.Count * .50)
            findings.Add(new("CPU_SATURATION","Sustained CPU saturation","CPU utilization remained near saturation for a substantial portion of the session.",FindingSeverity.Medium,FindingConfidence.Medium,
                [$"CPU-saturated samples: {cpuSat}/{samples.Count}"],["High CPU use can be healthy during CPU-bound exports."],["Interpret this finding in the context of the Lightroom workload."]));

        return findings.Count == 0
            ? [new("NO_ENDPOINT_CONSTRAINT","No endpoint constraint established","The available telemetry did not establish sustained CPU, memory, or storage pressure.",FindingSeverity.Info,FindingConfidence.Medium,[],["Absence of evidence is not proof that Lightroom was responsive."],[])]
            : findings;
    }

    private static DiagnosticFinding Insufficient(string reason) => new("INSUFFICIENT_EVIDENCE","Insufficient evidence",reason,FindingSeverity.Info,FindingConfidence.Low,[],[],[]);
}
