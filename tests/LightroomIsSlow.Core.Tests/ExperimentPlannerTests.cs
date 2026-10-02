using LightroomIsSlow.Core.Experiments;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class ExperimentPlannerTests
{
 [Fact]public void InsufficientEvidenceProducesFocusedRepeat(){var f=new DiagnosticFinding("INSUFFICIENT_EVIDENCE","Not enough evidence","",FindingSeverity.Info,FindingConfidence.Low,[],[],[]);var x=new ExperimentPlanner().Recommend([f]);Assert.NotNull(x);Assert.Equal(ExperimentPurpose.IncreaseEvidence,x!.Purpose);}
 [Fact]public void NoConstraintDoesNotBecomeAForcedDiagnosis(){var f=new DiagnosticFinding("NO_ENDPOINT_CONSTRAINT","No endpoint constraint","",FindingSeverity.Info,FindingConfidence.Medium,[],[],[]);var x=new ExperimentPlanner().Recommend([f]);Assert.Equal("MARK_OBSERVED_STALL",x!.Code);}
}
