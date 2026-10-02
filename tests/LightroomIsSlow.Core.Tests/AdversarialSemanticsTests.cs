using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class AdversarialSemanticsTests
{
 [Fact]public void PageReadsWithoutLowMemoryDoNotTriggerMemoryPressure(){var t=DateTimeOffset.UnixEpoch;var s=Enumerable.Range(0,50).Select(i=>new TelemetrySample{TimestampUtc=t.AddSeconds(i),SessionId="x",MemoryAvailableMb=16000,MemoryPageReadsPerSecond=1000,CpuSystemPercent=10}).ToArray();Assert.DoesNotContain(new DiagnosticEngine().Evaluate(s),x=>x.Code=="MEMORY_PRESSURE");}
 [Fact]public void LowMemoryWithoutPagingDoesNotTriggerMemoryPressure(){var t=DateTimeOffset.UnixEpoch;var s=Enumerable.Range(0,50).Select(i=>new TelemetrySample{TimestampUtc=t.AddSeconds(i),SessionId="x",MemoryAvailableMb=500,MemoryPageReadsPerSecond=0,CpuSystemPercent=10}).ToArray();Assert.DoesNotContain(new DiagnosticEngine().Evaluate(s),x=>x.Code=="MEMORY_PRESSURE");}
}
