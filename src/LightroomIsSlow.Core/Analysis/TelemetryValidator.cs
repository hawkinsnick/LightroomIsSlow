using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Analysis;
public static class TelemetryValidator
{
 public static IReadOnlyList<string> Validate(IReadOnlyList<TelemetrySample> s)
 {
  var w=new List<string>();if(s.Any(x=>InvalidPercent(x.CpuSystemPercent)||InvalidPercent(x.CpuLightroomPercent)||InvalidPercent(x.GpuComputePercent)))w.Add("One or more utilization measurements were outside 0-100% or non-finite.");
  if(s.Any(x=>Negative(x.MemoryAvailableMb)||Negative(x.DiskReadLatencyMs)||Negative(x.DiskWriteLatencyMs)||Negative(x.DiskQueueDepth)||Negative(x.NetworkReceiveBytesPerSecond)||Negative(x.NetworkSendBytesPerSecond)))w.Add("One or more non-negative measurements contained an invalid negative or non-finite value.");
  var ordered=s.OrderBy(x=>x.TimestampUtc).ToArray();if(ordered.Zip(ordered.Skip(1),(a,b)=>(b.TimestampUtc-a.TimestampUtc).TotalSeconds).Any(g=>g>3))w.Add("Telemetry contains a sampling gap longer than three seconds.");return w;
 }
 static bool InvalidPercent(double? x)=>x.HasValue&&(!double.IsFinite(x.Value)||x<0||x>100);static bool Negative(double? x)=>x.HasValue&&(!double.IsFinite(x.Value)||x<0);
}
