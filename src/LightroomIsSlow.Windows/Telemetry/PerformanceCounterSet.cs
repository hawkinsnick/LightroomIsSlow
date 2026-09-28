using System.Diagnostics;
namespace LightroomIsSlow.Windows.Telemetry;
internal sealed class PerformanceCounterSet:IDisposable{private readonly List<PerformanceCounter> _c=[];public PerformanceCounter Add(string cat,string ctr,string inst="_Total"){var c=new PerformanceCounter(cat,ctr,inst,true);_=c.NextValue();_c.Add(c);return c;}public static double? Read(PerformanceCounter? c,double scale=1){if(c is null)return null;try{return c.NextValue()*scale;}catch{return null;}}public void Dispose(){foreach(var c in _c)c.Dispose();}}
