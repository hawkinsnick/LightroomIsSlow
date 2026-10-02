namespace LightroomIsSlow.Core.Models;
public enum MeasurementQuality{Unavailable,Contextual,Measured,Attributed}
public sealed record MeasurementStatus(string Metric,MeasurementQuality Quality,string Source,string? Note=null);
public sealed record CollectorHealth(IReadOnlyList<MeasurementStatus> Measurements)
{
 public MeasurementStatus? For(string metric)=>Measurements.FirstOrDefault(x=>x.Metric==metric);
}
