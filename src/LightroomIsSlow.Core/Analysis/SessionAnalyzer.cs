using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Analysis;

public sealed class SessionAnalyzer
{
    public SessionSummary Summarize(IReadOnlyList<TelemetrySample> samples)
    {
        if (samples.Count == 0) throw new ArgumentException("At least one sample is required.", nameof(samples));
        return new SessionSummary(
            samples.Count,
            Mean(samples.Select(x => x.CpuSystemPercent)),
            Mean(samples.Select(x => x.CpuLightroomPercent)),
            Min(samples.Select(x => x.MemoryAvailableMb)),
            P95(samples.Select(x => x.DiskReadLatencyMs)),
            P95(samples.Select(x => x.DiskWriteLatencyMs)),
            Max(samples.Select(x => x.GpuComputePercent)),
            Max(samples.Select(x => x.GpuVramUsedMb)));
    }

    private static double? Mean(IEnumerable<double?> values) { var a=values.Where(x=>x.HasValue).Select(x=>x!.Value).ToArray(); return a.Length==0?null:a.Average(); }
    private static double? Min(IEnumerable<double?> values) { var a=values.Where(x=>x.HasValue).Select(x=>x!.Value).ToArray(); return a.Length==0?null:a.Min(); }
    private static double? Max(IEnumerable<double?> values) { var a=values.Where(x=>x.HasValue).Select(x=>x!.Value).ToArray(); return a.Length==0?null:a.Max(); }
    private static double? P95(IEnumerable<double?> values) { var a=values.Where(x=>x.HasValue).Select(x=>x!.Value).OrderBy(x=>x).ToArray(); return a.Length==0?null:a[(int)Math.Ceiling(.95*a.Length)-1]; }
}

public sealed record SessionSummary(int SampleCount,double? CpuSystemAveragePercent,double? CpuLightroomAveragePercent,double? MemoryAvailableMinimumMb,double? DiskReadLatencyP95Ms,double? DiskWriteLatencyP95Ms,double? GpuComputePeakPercent,double? GpuVramPeakMb);
