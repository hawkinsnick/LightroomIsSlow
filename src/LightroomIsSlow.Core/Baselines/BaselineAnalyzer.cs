using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Baselines;
public sealed class BaselineAnalyzer
{
 public SessionBaseline Build(string applicationId,WorkloadKind workload,IReadOnlyList<IReadOnlyList<TelemetrySample>> sessions)
 {
  var all=sessions.SelectMany(x=>x).ToArray();return new(applicationId,workload,sessions.Count,Median(all.Select(x=>x.CpuSystemPercent)),Median(all.Select(x=>x.DiskReadLatencyMs)),Percentile(all.Select(x=>x.DiskReadLatencyMs),.95),all.Where(x=>x.MemoryAvailableMb.HasValue).Select(x=>x.MemoryAvailableMb!.Value).DefaultIfEmpty().Min());
 }
 public IReadOnlyList<BaselineComparison> Compare(SessionBaseline b,IReadOnlyList<TelemetrySample> current)
 {
  var r=new List<BaselineComparison>();Add(r,"cpu.system",current.Where(x=>x.CpuSystemPercent.HasValue).Select(x=>x.CpuSystemPercent!.Value).DefaultIfEmpty().Average(),b.MedianCpuPercent);Add(r,"storage.read_latency",Median(current.Select(x=>x.DiskReadLatencyMs)),b.MedianStorageReadLatencyMs);return r;
 }
 static void Add(List<BaselineComparison> r,string m,double? c,double? b){if(c is null||b is null||b==0)return;var d=(c.Value-b.Value)*100/b.Value;r.Add(new(m,c.Value,b.Value,d,Math.Abs(d)<20?"similar to local baseline":d>0?"above local baseline":"below local baseline"));}
 static double? Median(IEnumerable<double?> xs)=>Percentile(xs,.5);
 static double? Percentile(IEnumerable<double?> xs,double p){var a=xs.Where(x=>x.HasValue).Select(x=>x!.Value).Order().ToArray();if(a.Length==0)return null;var i=(int)Math.Clamp(Math.Ceiling(p*a.Length)-1,0,a.Length-1);return a[i];}
}
