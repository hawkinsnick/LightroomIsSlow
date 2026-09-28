using System.Text.Json;
using LightroomIsSlow.Core.Models;
using LightroomIsSlow.Core.Serialization;

namespace LightroomIsSlow.Core.Sessions;

public sealed class SessionWriter : IAsyncDisposable
{
    private readonly string _directory;
    private readonly StreamWriter _telemetry;
    public string DirectoryPath => _directory;

    public SessionWriter(string root, string sessionId)
    {
        _directory = Path.Combine(root, sessionId);
        Directory.CreateDirectory(_directory);
        _telemetry = new StreamWriter(Path.Combine(_directory, "telemetry.jsonl"), append:false);
    }

    public async Task WriteMetadataAsync(SessionMetadata metadata, CancellationToken ct=default) =>
        await File.WriteAllTextAsync(Path.Combine(_directory,"session.json"),JsonSerializer.Serialize(metadata,SessionJson.Options),ct);

    public async Task WriteSampleAsync(TelemetrySample sample)
    {
        await _telemetry.WriteLineAsync(JsonSerializer.Serialize(sample,SessionJson.Options));
        await _telemetry.FlushAsync();
    }

    public async ValueTask DisposeAsync() => await _telemetry.DisposeAsync();
}
