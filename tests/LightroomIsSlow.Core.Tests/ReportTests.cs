using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Validation;
namespace LightroomIsSlow.Core.Tests;
public sealed class ReportTests{[Fact]public void ReportExposesWhy(){var r=new DiagnosticReportBuilder().Build("x",SyntheticTraceFactory.StoragePressure());var md=MarkdownReportRenderer.Render(r);Assert.Contains("STORAGE_PRESSURE",md);Assert.Contains("Evidence",md);Assert.Contains("Confidence",md);}}
