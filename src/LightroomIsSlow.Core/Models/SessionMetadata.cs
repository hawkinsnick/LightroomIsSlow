namespace LightroomIsSlow.Core.Models;

public sealed record SessionMetadata
{
    public required string SessionId { get; init; }
    public required string SchemaVersion { get; init; }
    public required string AppVersion { get; init; }
    public required DateTimeOffset StartedUtc { get; init; }
    public DateTimeOffset? EndedUtc { get; init; }
    public required TimeSpan SampleInterval { get; init; }
    public ProcessIdentity? LightroomProcess { get; init; }
    public string? WorkloadLabel { get; init; }
    public SystemInventory? System { get; init; }
    public PlatformHealthSnapshot? PlatformHealth { get; init; }
    public IReadOnlyList<MetricProvenance> Provenance { get; init; } = [];
}
