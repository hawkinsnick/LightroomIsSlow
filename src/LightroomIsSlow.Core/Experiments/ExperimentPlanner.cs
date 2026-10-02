using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Experiments;
public sealed class ExperimentPlanner
{
 public DiagnosticExperiment? Recommend(IReadOnlyList<DiagnosticFinding> findings,WorkloadKind workload=WorkloadKind.Unknown)
 {
  if(findings.Any(x=>x.Code=="INSUFFICIENT_EVIDENCE"))return new("REPEAT_FOCUSED_SESSION","Record a focused slowdown","Start recording immediately before the slowdown, reproduce it once, then stop recording.",ExperimentPurpose.IncreaseEvidence,workload,TimeSpan.FromMinutes(3),["cpu","memory","storage","gpu","network"],"The current session does not contain enough evidence for a supported diagnosis.");
  var storage=findings.FirstOrDefault(x=>x.Code=="STORAGE_PRESSURE");var cpu=findings.FirstOrDefault(x=>x.Code=="CPU_SATURATION");
  if(storage is not null&&cpu is not null)return new("REPEAT_SAME_WORKLOAD","Repeat the same workload once","Repeat the same Lightroom action under the same conditions and record the complete operation.",ExperimentPurpose.DistinguishCompetingHypotheses,workload,TimeSpan.FromMinutes(5),["cpu","storage","memory"],"CPU and storage findings coexist; a repeated complete workload can test persistence and temporal ordering.");
  if(findings.Count==1&&findings[0].Code=="NO_ENDPOINT_CONSTRAINT")return new("MARK_OBSERVED_STALL","Capture a session centered on the visible stall","Start recording just before the problem, reproduce the visible stall, and stop shortly afterward.",ExperimentPurpose.IncreaseEvidence,workload,TimeSpan.FromMinutes(2),["cpu","memory","storage","gpu","network"],"No endpoint constraint was demonstrated; a tighter window reduces unrelated healthy activity.");
  return null;
 }
}
