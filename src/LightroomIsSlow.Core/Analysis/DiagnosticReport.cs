using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Analysis;
public sealed record DiagnosticReport(string SessionId,DateTimeOffset GeneratedUtc,SessionSummary Summary,IReadOnlyList<DiagnosticFinding> Findings);
public sealed class DiagnosticReportBuilder
{
 public DiagnosticReport Build(string id,IReadOnlyList<TelemetrySample> samples)=>new(id,DateTimeOffset.UtcNow,new SessionAnalyzer().Summarize(samples),new DiagnosticEngine().Evaluate(samples));
}
