using System.Diagnostics;
namespace LightroomIsSlow.Windows.Telemetry;
internal sealed class WindowsPerformanceCounters:IDisposable
{
 private readonly PerformanceCounterSet s=new(); public PerformanceCounter? Faults,DR,DW,DRL,DWL,DQ,NR,NT,GU,GD,GS;
 public WindowsPerformanceCounters(){Faults=T(()=>s.Add("Memory","Page Reads/sec",""));DR=T(()=>s.Add("PhysicalDisk","Disk Read Bytes/sec"));DW=T(()=>s.Add("PhysicalDisk","Disk Write Bytes/sec"));DRL=T(()=>s.Add("PhysicalDisk","Avg. Disk sec/Read"));DWL=T(()=>s.Add("PhysicalDisk","Avg. Disk sec/Write"));DQ=T(()=>s.Add("PhysicalDisk","Current Disk Queue Length"));var n=I("Network Interface");if(n!=null){NR=T(()=>s.Add("Network Interface","Bytes Received/sec",n));NT=T(()=>s.Add("Network Interface","Bytes Sent/sec",n));}var g=I("GPU Engine");if(g!=null)GU=T(()=>s.Add("GPU Engine","Utilization Percentage",g));var m=I("GPU Process Memory");if(m!=null){GD=T(()=>s.Add("GPU Process Memory","Dedicated Usage",m));GS=T(()=>s.Add("GPU Process Memory","Shared Usage",m));}}
 static T? T<T>(Func<T> f) where T:class{try{return f();}catch{return null;}} static string? I(string c){try{return new PerformanceCounterCategory(c).GetInstanceNames().FirstOrDefault();}catch{return null;}} public void Dispose()=>s.Dispose();
}
