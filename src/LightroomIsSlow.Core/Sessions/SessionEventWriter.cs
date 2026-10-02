using System.Text.Json;using LightroomIsSlow.Core.Models;using LightroomIsSlow.Core.Serialization;
namespace LightroomIsSlow.Core.Sessions;
public static class SessionEventWriter
{
 public static async Task AppendAsync(string directory,SessionEvent value,CancellationToken ct=default){Directory.CreateDirectory(directory);var path=Path.Combine(directory,"events.jsonl");await File.AppendAllTextAsync(path,JsonSerializer.Serialize(value,SessionJson.Options)+Environment.NewLine,ct);}
 public static async Task<IReadOnlyList<SessionEvent>> ReadAsync(string directory,CancellationToken ct=default){var path=Path.Combine(directory,"events.jsonl");if(!File.Exists(path))return[];var r=new List<SessionEvent>();await foreach(var line in File.ReadLinesAsync(path,ct)){if(string.IsNullOrWhiteSpace(line))continue;var x=JsonSerializer.Deserialize<SessionEvent>(line,SessionJson.Options);if(x is not null)r.Add(x);}return r;}
}
