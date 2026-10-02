using LightroomIsSlow.Core.Abstractions;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Mac;
public sealed class MacTelemetryCollector:ITelemetryCollector
{
 private ProcessIdentity? target;
 public ValueTask InitializeAsync(ProcessIdentity? target,CancellationToken ct=default){this.target=target;return ValueTask.CompletedTask;}
 public ValueTask<TelemetrySample> CollectAsync(string sessionId,CancellationToken ct=default)=>ValueTask.FromResult(new TelemetrySample{TimestampUtc=DateTimeOffset.UtcNow,SessionId=sessionId,LightroomProcessId=target?.ProcessId});
 public ValueTask DisposeAsync()=>ValueTask.CompletedTask;
}
