using LightroomIsSlow.Core.Analysis;
using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Tests;

public sealed class DiagnosticEngineTests
{
    [Fact]
    public void StoragePressureRequiresCorroboratingQueueAndCpuHeadroom()
    {
        var samples=Enumerable.Range(0,20).Select(i=>new TelemetrySample{
            TimestampUtc=DateTimeOffset.UtcNow.AddSeconds(i),SessionId="x",
            CpuSystemPercent=40,DiskReadLatencyMs=35,DiskQueueDepth=4,MemoryAvailableMb=8192
        }).ToArray();
        var result=new DiagnosticEngine().Evaluate(samples);
        Assert.Contains(result,x=>x.Code=="STORAGE_PRESSURE");
    }

    [Fact]
    public void HealthyTelemetryDoesNotInventBottleneck()
    {
        var samples=Enumerable.Range(0,20).Select(i=>new TelemetrySample{
            TimestampUtc=DateTimeOffset.UtcNow.AddSeconds(i),SessionId="x",
            CpuSystemPercent=30,DiskReadLatencyMs=2,DiskQueueDepth=.1,MemoryAvailableMb=8192,MemoryPageReadsPerSecond=0
        }).ToArray();
        var result=new DiagnosticEngine().Evaluate(samples);
        Assert.Single(result);
        Assert.Equal("NO_ENDPOINT_CONSTRAINT",result[0].Code);
    }

    [Fact]
    public void ShortTraceReturnsInsufficientEvidence()
    {
        var samples=Enumerable.Range(0,3).Select(i=>new TelemetrySample{TimestampUtc=DateTimeOffset.UtcNow,SessionId="x"}).ToArray();
        Assert.Equal("INSUFFICIENT_EVIDENCE",new DiagnosticEngine().Evaluate(samples).Single().Code);
    }
}
