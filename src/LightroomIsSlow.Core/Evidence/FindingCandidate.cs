using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Evidence;
public sealed record FindingCandidate(string Code,string Hypothesis,IReadOnlyList<EvidenceItem> Evidence,IReadOnlyList<EvidenceItem> CounterEvidence,FindingConfidence Confidence);
