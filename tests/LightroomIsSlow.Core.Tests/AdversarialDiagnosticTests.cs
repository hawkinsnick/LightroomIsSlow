using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class AdversarialDiagnosticTests
{
 [Fact]public void OneDiskSpikeDoesNotDiagnoseStorage(){var s=Enumerable.Range(0,100).Select(i=>new TelemetrySample{TimestampUtc=DateTimeOffset.UnixEpoch.AddSeconds(i),SessionId="x",CpuSystemPercent=30,DiskReadLatencyMs=i==50?500:2,DiskQueueDepth=i==50?30:.1,MemoryAvailableMb=8000}).ToArray();Assert.DoesNotContain(new DiagnosticEngine().Evaluate(s),x=>x.Code=="STORAGE_PRESSURE");}
 [Fact]public void HighDiskLatencyWithoutQueueDoesNotDiagnoseStorage(){var s=Enumerable.Range(0,100).Select(i=>new TelemetrySample{TimestampUtc=DateTimeOffset.UnixEpoch.AddSeconds(i),SessionId="x",CpuSystemPercent=30,DiskReadLatencyMs=50,DiskQueueDepth=.1}).ToArray();Assert.DoesNotContain(new DiagnosticEngine().Evaluate(s),x=>x.Code=="STORAGE_PRESSURE");}
 [Fact]public void LowMemoryWithoutFaultsDoesNotDiagnoseMemory(){var s=Enumerable.Range(0,100).Select(i=>new TelemetrySample{TimestampUtc=DateTimeOffset.UnixEpoch.AddSeconds(i),SessionId="x",CpuSystemPercent=30,MemoryAvailableMb=500,MemoryHardFaultsPerSecond=0}).ToArray();Assert.DoesNotContain(new DiagnosticEngine().Evaluate(s),x=>x.Code=="MEMORY_PRESSURE");}
}
