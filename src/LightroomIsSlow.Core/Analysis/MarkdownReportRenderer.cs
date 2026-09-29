using System.Text;
namespace LightroomIsSlow.Core.Analysis;
public static class MarkdownReportRenderer
{
 public static string Render(DiagnosticReport r){var b=new StringBuilder();b.AppendLine("# LightroomIsSlow Diagnostic Report").AppendLine().AppendLine($"Session: `{r.SessionId}`").AppendLine($"Samples: {r.Summary.SampleCount}").AppendLine().AppendLine("## Findings");
 foreach(var f in r.Findings){b.AppendLine().AppendLine($"### {f.Title}").AppendLine($"**Code:** `{f.Code}`  ").AppendLine($"**Confidence:** {f.Confidence}  ").AppendLine($"**Severity:** {f.Severity}").AppendLine().AppendLine(f.Explanation);if(f.Evidence.Count>0){b.AppendLine().AppendLine("**Evidence**");foreach(var x in f.Evidence)b.AppendLine($"- {x}");}if(f.CounterEvidence.Count>0){b.AppendLine().AppendLine("**Counter-evidence**");foreach(var x in f.CounterEvidence)b.AppendLine($"- {x}");}if(f.Recommendations.Count>0){b.AppendLine().AppendLine("**Recommendations**");foreach(var x in f.Recommendations)b.AppendLine($"- {x}");}}
 return b.ToString();}
}
