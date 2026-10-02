using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class TelemetryValidatorTests
{
 [Fact]public void RejectsImpossibleValues(){var s=new[]{new TelemetrySample{TimestampUtc=DateTimeOffset.UnixEpoch,SessionId="x",CpuSystemPercent=double.NaN,DiskQueueDepth=-1}};Assert.NotEmpty(TelemetryValidator.Validate(s));}
 [Fact]public void ReportsSamplingGap(){var t=DateTimeOffset.UnixEpoch;var s=new[]{new TelemetrySample{TimestampUtc=t,SessionId="x"},new TelemetrySample{TimestampUtc=t.AddSeconds(5),SessionId="x"}};Assert.Contains(TelemetryValidator.Validate(s),x=>x.Contains("sampling gap"));}
}
