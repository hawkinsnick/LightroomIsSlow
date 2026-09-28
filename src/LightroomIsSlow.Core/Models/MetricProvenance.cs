namespace LightroomIsSlow.Core.Models;

public sealed record MetricProvenance(string Metric,string Source,string? CounterPath=null,string? Note=null);
