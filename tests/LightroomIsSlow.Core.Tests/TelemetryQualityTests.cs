using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class TelemetryQualityTests{[Fact]public void MissingGpuIsReportedAsMissingNotHealthy(){var s=Enumerable.Range(0,20).Select(i=>new TelemetrySample{TimestampUtc=DateTimeOffset.UnixEpoch.AddSeconds(i),SessionId="x",CpuSystemPercent=10}).ToArray();var q=TelemetryQualityReport.Build(s);Assert.Contains(q.Warnings,x=>x.Contains("gpu.compute"));}}
