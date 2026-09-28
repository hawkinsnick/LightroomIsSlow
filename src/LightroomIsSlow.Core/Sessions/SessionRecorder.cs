using LightroomIsSlow.Core.Abstractions;
using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Sessions;

public sealed class SessionRecorder
{
    private readonly ITelemetryCollector _collector;
    public SessionRecorder(ITelemetryCollector collector) => _collector=collector;

    public async Task<int> RecordAsync(SessionMetadata metadata, SessionWriter writer, TimeSpan duration, CancellationToken ct=default)
    {
        await _collector.InitializeAsync(metadata.LightroomProcess,ct);
        await writer.WriteMetadataAsync(metadata,ct);
        var count=0;
        using var timer=new PeriodicTimer(metadata.SampleInterval);
        var end=DateTimeOffset.UtcNow+duration;
        while(DateTimeOffset.UtcNow<end && await timer.WaitForNextTickAsync(ct))
        {
            await writer.WriteSampleAsync(await _collector.CollectAsync(metadata.SessionId,ct));
            count++;
        }
        return count;
    }
}
