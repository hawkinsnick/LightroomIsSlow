using System.Diagnostics;
using LightroomIsSlow.Core.Abstractions;
using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Windows.Telemetry;

public sealed class WindowsTelemetryCollector : ITelemetryCollector
{
    private ProcessIdentity? _target;
    private Process? _process;
    private TimeSpan _lastCpu;
    private DateTimeOffset _lastAt;

    public ValueTask InitializeAsync(ProcessIdentity? lightroomProcess, CancellationToken cancellationToken=default)
    {
        _target=lightroomProcess;
        if(_target is not null)
        {
            try { _process=Process.GetProcessById(_target.ProcessId); _lastCpu=_process.TotalProcessorTime; _lastAt=DateTimeOffset.UtcNow; }
            catch { _process=null; }
        }
        return ValueTask.CompletedTask;
    }

    public ValueTask<TelemetrySample> CollectAsync(string sessionId, CancellationToken cancellationToken=default)
    {
        var now=DateTimeOffset.UtcNow;
        double? processCpu=null;
        if(_process is not null)
        {
            try
            {
                _process.Refresh();
                var cpu=_process.TotalProcessorTime;
                var elapsed=(now-_lastAt).TotalMilliseconds;
                if(elapsed>0) processCpu=Math.Clamp((cpu-_lastCpu).TotalMilliseconds/(elapsed*Environment.ProcessorCount)*100,0,100);
                _lastCpu=cpu; _lastAt=now;
            } catch { processCpu=null; }
        }

        var gc=GC.GetGCMemoryInfo();
        var totalMb=gc.TotalAvailableMemoryBytes>0?gc.TotalAvailableMemoryBytes/1048576d:(double?)null;
        return ValueTask.FromResult(new TelemetrySample
        {
            TimestampUtc=now, SessionId=sessionId, LightroomProcessId=_target?.ProcessId,
            CpuLightroomPercent=processCpu,
            MemoryAvailableMb=totalMb
        });
    }

    public ValueTask DisposeAsync() { _process?.Dispose(); return ValueTask.CompletedTask; }
}
