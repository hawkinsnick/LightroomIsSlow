namespace LightroomIsSlow.Core.Models;

public sealed record SystemInventory
{
    public required string MachineName { get; init; }
    public required string OsDescription { get; init; }
    public required string OsArchitecture { get; init; }
    public required int LogicalProcessorCount { get; init; }
    public required long TotalPhysicalMemoryBytes { get; init; }
    public IReadOnlyList<string> Gpus { get; init; } = [];
    public IReadOnlyList<string> Disks { get; init; } = [];
}
