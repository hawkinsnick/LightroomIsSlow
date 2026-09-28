using System.Text.Json;
using LightroomIsSlow.Core.Models;
using LightroomIsSlow.Core.Serialization;

namespace LightroomIsSlow.Core.Sessions;

public static class SessionReader
{
    public static async Task<IReadOnlyList<TelemetrySample>> ReadSamplesAsync(string directory, CancellationToken ct=default)
    {
        var result=new List<TelemetrySample>();
        var path=Path.Combine(directory,"telemetry.jsonl");
        await foreach(var line in File.ReadLinesAsync(path,ct))
        {
            if(string.IsNullOrWhiteSpace(line)) continue;
            var sample=JsonSerializer.Deserialize<TelemetrySample>(line,SessionJson.Options);
            if(sample is not null) result.Add(sample);
        }
        return result;
    }
}
