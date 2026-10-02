using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Experiments;
public enum ExperimentPurpose{IncreaseEvidence,DistinguishCompetingHypotheses,VerifyReproducibility}
public sealed record DiagnosticExperiment(string Code,string Title,string Instructions,ExperimentPurpose Purpose,WorkloadKind Workload,TimeSpan SuggestedDuration,IReadOnlyList<string> MeasurementsNeeded,string Rationale);
