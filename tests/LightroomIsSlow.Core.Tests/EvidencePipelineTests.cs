using LightroomIsSlow.Core.Evidence;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class EvidencePipelineTests
{
 [Fact]public void CandidateKeepsSupportAndCounterEvidenceSeparate(){var o=new DiagnosticObservation("storage.read_latency",40,"ms",DateTimeOffset.UtcNow,"synthetic");var yes=new EvidenceItem("LATENCY","Latency elevated",EvidenceDisposition.Supports,[o]);var no=new EvidenceItem("CPU_BUSY","CPU also saturated",EvidenceDisposition.Contradicts,[]);var c=new FindingCandidate("STORAGE_PRESSURE","Storage constrained the workload",[yes],[no],FindingConfidence.Medium);Assert.Single(c.Evidence);Assert.Single(c.CounterEvidence);}
}
