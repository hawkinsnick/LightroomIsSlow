using LightroomIsSlow.Core.Abstractions;
using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Windows.Telemetry;

public sealed class PlaceholderWindowsTelemetryCollector : ITelemetryCollector
{
    private ProcessIdentity? _lightroomProcess;

    public ValueTask InitializeAsync(ProcessIdentity? lightroomProcess, CancellationToken cancellationToken = default)
    {
        _lightroomProcess = lightroomProcess;
        return ValueTask.CompletedTask;
    }

    public ValueTask<TelemetrySample> CollectAsync(string sessionId, CancellationToken cancellationToken = default)
    {
        // v0.1 scaffolding: real PDH-backed collectors replace these null fields next.
        return ValueTask.FromResult(new TelemetrySample
        {
            TimestampUtc = DateTimeOffset.UtcNow,
            SessionId = sessionId,
            LightroomProcessId = _lightroomProcess?.ProcessId
        });
    }

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}
