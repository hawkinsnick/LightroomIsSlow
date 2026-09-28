namespace LightroomIsSlow.Core.Models;

public enum FindingSeverity { Info, Low, Medium, High }
public enum FindingConfidence { Low, Medium, High }

public sealed record DiagnosticFinding(
    string Code,
    string Title,
    string Explanation,
    FindingSeverity Severity,
    FindingConfidence Confidence,
    IReadOnlyList<string> Evidence,
    IReadOnlyList<string> CounterEvidence,
    IReadOnlyList<string> Recommendations);
