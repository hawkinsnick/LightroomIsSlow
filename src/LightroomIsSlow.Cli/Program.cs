using LightroomIsSlow.Core.Analysis;
using LightroomIsSlow.Core.Models;
using LightroomIsSlow.Core.Sessions;
using LightroomIsSlow.Windows.Processes;
using LightroomIsSlow.Windows.Telemetry;
using LightroomIsSlow.Windows.Inventory;
using LightroomIsSlow.Windows.Health;

const string Version="0.9.0";
var command=args.FirstOrDefault()?.ToLowerInvariant() ?? "help";
var detector=new WindowsLightroomProcessDetector();

if(command=="detect")
{
    var ps=detector.Detect();
    if(ps.Count==0){ Console.WriteLine("No supported Lightroom process detected."); return 1; }
    foreach(var p in ps) Console.WriteLine($"{p.Product}: {p.ProcessName} (PID {p.ProcessId}) {p.ProductVersion}");
    return 0;
}

if(command=="record")
{
    var seconds=300;
    var i=Array.IndexOf(args,"--duration");
    if(i>=0 && i+1<args.Length && int.TryParse(args[i+1],out var parsed) && parsed>0) seconds=parsed;
    var target=detector.Detect().FirstOrDefault();
    var id=DateTimeOffset.UtcNow.ToString("yyyyMMddTHHmmssZ");
    var metadata=new SessionMetadata{SessionId=id,SchemaVersion="1.0",AppVersion=Version,StartedUtc=DateTimeOffset.UtcNow,SampleInterval=TimeSpan.FromSeconds(1),LightroomProcess=target,System=new WindowsSystemInventoryProvider().Capture(),WindowsHealth=new WindowsHealthProvider().Capture(),Provenance=[new("cpu.system","GetSystemTimes"),new("cpu.lightroom","Process.TotalProcessorTime"),new("memory","GlobalMemoryStatusEx"),new("memory.hard_faults","PerformanceCounter","Memory/Page Reads/sec"),new("disk","PerformanceCounter","PhysicalDisk/_Total"),new("network","PerformanceCounter","Network Interface"),new("gpu","PerformanceCounter","GPU Engine / GPU Process Memory")]};
    await using var writer=new SessionWriter("sessions",id);
    await using var collector=new WindowsTelemetryCollector();
    var recorder=new SessionRecorder(collector);
    Console.WriteLine(target is null?"Recording endpoint telemetry; Lightroom not detected.":$"Recording {target.Product} PID {target.ProcessId}...");
    var count=await recorder.RecordAsync(metadata,writer,TimeSpan.FromSeconds(seconds));
    Console.WriteLine($"Session complete: {count} samples -> {writer.DirectoryPath}");
    return 0;
}

if(command=="analyze")
{
    if(args.Length<2){Console.Error.WriteLine("Usage: lightroomisslow analyze <session-directory>"); return 2;}
    var samples=await SessionReader.ReadSamplesAsync(args[1]);
    if(samples.Count==0){Console.Error.WriteLine("Session contains no telemetry samples."); return 2;}
    var summary=new SessionAnalyzer().Summarize(samples);
    Console.WriteLine($"Samples: {summary.SampleCount}");
    Console.WriteLine($"Lightroom CPU avg: {summary.CpuLightroomAveragePercent:F1}%");
    Console.WriteLine($"Disk read latency p95: {summary.DiskReadLatencyP95Ms:F1} ms");
    foreach(var finding in new DiagnosticEngine().Evaluate(samples))
    {
        Console.WriteLine($"\n[{finding.Confidence}] {finding.Title} ({finding.Code})");
        Console.WriteLine(finding.Explanation);
        foreach(var e in finding.Evidence) Console.WriteLine($"  Evidence: {e}");
        foreach(var e in finding.CounterEvidence) Console.WriteLine($"  Counter-evidence: {e}");
        foreach(var r in finding.Recommendations) Console.WriteLine($"  Recommendation: {r}");
    }
    return 0;
}

Console.WriteLine($"LightroomIsSlow {Version}");
Console.WriteLine("Commands: detect | record [--duration seconds] | analyze <session-directory>");
return 0;
