using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Abstractions;

public interface ITelemetryCollector : IAsyncDisposable
{
    ValueTask InitializeAsync(ProcessIdentity? lightroomProcess, CancellationToken cancellationToken = default);
    ValueTask<TelemetrySample> CollectAsync(string sessionId, CancellationToken cancellationToken = default);
}
