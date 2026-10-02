namespace LightroomIsSlow.Core.Evidence;
public enum EvidenceDisposition{Supports,Contradicts,Context,Unknown}
public sealed record EvidenceItem(string Code,string Statement,EvidenceDisposition Disposition,IReadOnlyList<DiagnosticObservation> Observations);
