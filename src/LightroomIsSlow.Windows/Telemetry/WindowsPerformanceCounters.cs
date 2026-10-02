using System.Diagnostics;
namespace LightroomIsSlow.Windows.Telemetry;
internal sealed class WindowsPerformanceCounters:IDisposable
{
 private readonly PerformanceCounterSet s=new(); private readonly List<PerformanceCounter> nr=[],nt=[],gu=[],gd=[];
 public PerformanceCounter? Faults,DR,DW,DRL,DWL,DQ;
 public WindowsPerformanceCounters(){Faults=T(()=>s.Add("Memory","Page Reads/sec",""));DR=T(()=>s.Add("PhysicalDisk","Disk Read Bytes/sec"));DW=T(()=>s.Add("PhysicalDisk","Disk Write Bytes/sec"));DRL=T(()=>s.Add("PhysicalDisk","Avg. Disk sec/Read"));DWL=T(()=>s.Add("PhysicalDisk","Avg. Disk sec/Write"));DQ=T(()=>s.Add("PhysicalDisk","Current Disk Queue Length"));foreach(var n in Instances("Network Interface")){var r=T(()=>s.Add("Network Interface","Bytes Received/sec",n));var t=T(()=>s.Add("Network Interface","Bytes Sent/sec",n));if(r is not null)nr.Add(r);if(t is not null)nt.Add(t);}}
 public void BindProcess(int pid){foreach(var n in Instances("GPU Engine").Where(x=>x.Contains($"pid_{pid}_",StringComparison.OrdinalIgnoreCase))){var x=T(()=>s.Add("GPU Engine","Utilization Percentage",n));if(x is not null)gu.Add(x);}foreach(var n in Instances("GPU Process Memory").Where(x=>x.Contains($"pid_{pid}_",StringComparison.OrdinalIgnoreCase))){var x=T(()=>s.Add("GPU Process Memory","Dedicated Usage",n));if(x is not null)gd.Add(x);}}
 public double? NetworkReceive()=>Sum(nr);public double? NetworkSend()=>Sum(nt);public double? GpuUtilization()=>Sum(gu,100);public double? DedicatedGpuBytes()=>Sum(gd);
 static double? Sum(IEnumerable<PerformanceCounter> cs,double? cap=null){var values=cs.Select(x=>PerformanceCounterSet.Read(x)).Where(x=>x.HasValue).Select(x=>x!.Value).ToArray();if(values.Length==0)return null;var v=values.Sum();return cap.HasValue?Math.Min(cap.Value,v):v;}
 static T? T<T>(Func<T> f) where T:class{try{return f();}catch{return null;}}static IEnumerable<string> Instances(string c){try{return new PerformanceCounterCategory(c).GetInstanceNames();}catch{return[];}}public void Dispose()=>s.Dispose();
}