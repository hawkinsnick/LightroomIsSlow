using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Baselines;
public sealed record SessionBaseline(string ApplicationId,WorkloadKind Workload,int SessionCount,double? MedianCpuPercent,double? MedianStorageReadLatencyMs,double? P95StorageReadLatencyMs,double? MinimumMemoryAvailableMb);
public sealed record BaselineComparison(string Metric,double Current,double Baseline,double DifferencePercent,string Interpretation);
