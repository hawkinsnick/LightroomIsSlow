using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Analysis;
public sealed record MetricCoverage(string Metric,int Valid,int Total,double Percent);
public sealed record TelemetryQualityReport(int SampleCount,IReadOnlyList<MetricCoverage> Coverage,IReadOnlyList<string> Warnings)
{
 public static TelemetryQualityReport Build(IReadOnlyList<TelemetrySample> s)
 {
  var n=s.Count;var c=new List<MetricCoverage>();void Add(string m,Func<TelemetrySample,double?> f){var v=s.Count(x=>f(x).HasValue);c.Add(new(m,v,n,n==0?0:v*100d/n));}
  Add("cpu.system",x=>x.CpuSystemPercent);Add("cpu.lightroom",x=>x.CpuLightroomPercent);Add("memory.available",x=>x.MemoryAvailableMb);Add("storage.read_latency",x=>x.DiskReadLatencyMs);Add("storage.queue",x=>x.DiskQueueDepth);Add("gpu.compute",x=>x.GpuComputePercent);Add("network.receive",x=>x.NetworkReceiveBytesPerSecond);
  var w=c.Where(x=>x.Percent<50).Select(x=>$"{x.Metric} coverage is {x.Percent:0}%").ToList();if(n<10)w.Add("Too few samples for a defensible diagnosis.");return new(n,c,w);
 }
}
