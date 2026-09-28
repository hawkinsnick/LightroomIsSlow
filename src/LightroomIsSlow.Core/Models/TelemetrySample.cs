namespace LightroomIsSlow.Core.Models;

public sealed record TelemetrySample
{
    public required DateTimeOffset TimestampUtc { get; init; }
    public required string SessionId { get; init; }
    public int? LightroomProcessId { get; init; }

    public double? CpuSystemPercent { get; init; }
    public double? CpuLightroomPercent { get; init; }
    public double? CpuFrequencyMhz { get; init; }

    public double? MemoryAvailableMb { get; init; }
    public double? MemoryCommitPercent { get; init; }
    public double? MemoryHardFaultsPerSecond { get; init; }

    public double? DiskReadBytesPerSecond { get; init; }
    public double? DiskWriteBytesPerSecond { get; init; }
    public double? DiskReadLatencyMs { get; init; }
    public double? DiskWriteLatencyMs { get; init; }
    public double? DiskQueueDepth { get; init; }

    public double? Gpu3DPercent { get; init; }
    public double? GpuComputePercent { get; init; }
    public double? GpuVramUsedMb { get; init; }

    public double? NetworkReceiveBytesPerSecond { get; init; }
    public double? NetworkSendBytesPerSecond { get; init; }
}
