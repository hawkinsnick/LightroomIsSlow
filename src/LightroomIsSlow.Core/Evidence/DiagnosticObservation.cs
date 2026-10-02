namespace LightroomIsSlow.Core.Evidence;
public sealed record DiagnosticObservation(string Metric,double Value,string Unit,DateTimeOffset TimestampUtc,string Source,bool IsMeasured=true);
