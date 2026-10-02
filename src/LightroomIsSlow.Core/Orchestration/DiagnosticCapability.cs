namespace LightroomIsSlow.Core.Orchestration;
public sealed record DiagnosticCapability(DiagnosticCommand Command,string Description,bool RequiresActiveSession=false);
public static class DiagnosticCapabilities
{
 public static IReadOnlyList<DiagnosticCapability> All=>[
 new(DiagnosticCommand.InspectEnvironment,"Inspect platform and available diagnostic capabilities."),
 new(DiagnosticCommand.DetectLightroom,"Detect a supported Lightroom process."),
 new(DiagnosticCommand.StartSession,"Start a diagnostic recording."),
 new(DiagnosticCommand.StopSession,"Stop the active recording.",true),
 new(DiagnosticCommand.AnalyzeSession,"Run deterministic analysis."),
 new(DiagnosticCommand.ExplainFinding,"Explain evidence, counter-evidence, confidence, and unknowns."),
 new(DiagnosticCommand.CompareSessions,"Compare compatible diagnostic sessions."),
 new(DiagnosticCommand.CreateSupportBundle,"Create a privacy-safe support package."),
 new(DiagnosticCommand.RecommendNextTest,"Choose the smallest useful follow-up experiment.")];
}
