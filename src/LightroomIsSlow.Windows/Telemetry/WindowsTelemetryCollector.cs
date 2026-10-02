using System.Diagnostics;
using System.Runtime.InteropServices;
using LightroomIsSlow.Core.Abstractions;
using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Windows.Telemetry;

public sealed class WindowsTelemetryCollector : ITelemetryCollector
{
    private readonly WindowsPerformanceCounters _perf=new(); private ProcessIdentity? _target; private Process? _process; private TimeSpan _lastProcessCpu; private TimeSpan _lastSystemIdle; private TimeSpan _lastSystemKernel; private TimeSpan _lastSystemUser; private DateTimeOffset _lastAt;

    public ValueTask InitializeAsync(ProcessIdentity? target,CancellationToken ct=default)
    {
        _target=target; _lastAt=DateTimeOffset.UtcNow; ReadSystemTimes(out _lastSystemIdle,out _lastSystemKernel,out _lastSystemUser);
        if(target is not null) try{_process=Process.GetProcessById(target.ProcessId);_lastProcessCpu=_process.TotalProcessorTime;}catch{_process=null;}
        return ValueTask.CompletedTask;
    }

    public ValueTask<TelemetrySample> CollectAsync(string sessionId,CancellationToken ct=default)
    {
        var now=DateTimeOffset.UtcNow; double? pcpu=null,scpu=null;
        if(_process is not null) try{_process.Refresh();var cpu=_process.TotalProcessorTime;var ms=(now-_lastAt).TotalMilliseconds;if(ms>0)pcpu=Math.Clamp((cpu-_lastProcessCpu).TotalMilliseconds/(ms*Environment.ProcessorCount)*100,0,100);_lastProcessCpu=cpu;}catch{}
        if(ReadSystemTimes(out var idle,out var kernel,out var user)){var idleD=(idle-_lastSystemIdle).Ticks;var totalD=(kernel-_lastSystemKernel).Ticks+(user-_lastSystemUser).Ticks;if(totalD>0)scpu=Math.Clamp((1d-idleD/(double)totalD)*100,0,100);_lastSystemIdle=idle;_lastSystemKernel=kernel;_lastSystemUser=user;}
        GlobalMemoryStatusEx(out var mem);
        _lastAt=now;
        return ValueTask.FromResult(new TelemetrySample{TimestampUtc=now,SessionId=sessionId,LightroomProcessId=_target?.ProcessId,CpuSystemPercent=scpu,CpuLightroomPercent=pcpu,MemoryAvailableMb=mem.ullAvailPhys/1048576d,MemoryCommitPercent=mem.ullTotalPageFile==0?null:(mem.ullTotalPageFile-mem.ullAvailPageFile)*100d/mem.ullTotalPageFile,
            MemoryPageReadsPerSecond=PerformanceCounterSet.Read(_perf.Faults),
            DiskReadBytesPerSecond=PerformanceCounterSet.Read(_perf.DR),DiskWriteBytesPerSecond=PerformanceCounterSet.Read(_perf.DW),
            DiskReadLatencyMs=PerformanceCounterSet.Read(_perf.DRL,1000),DiskWriteLatencyMs=PerformanceCounterSet.Read(_perf.DWL,1000),DiskQueueDepth=PerformanceCounterSet.Read(_perf.DQ),
            GpuComputePercent=PerformanceCounterSet.Read(_perf.GU),GpuVramUsedMb=PerformanceCounterSet.Read(_perf.GD,1d/1048576),
            NetworkReceiveBytesPerSecond=PerformanceCounterSet.Read(_perf.NR),NetworkSendBytesPerSecond=PerformanceCounterSet.Read(_perf.NT)});
    }

    public ValueTask DisposeAsync(){_process?.Dispose();_perf.Dispose();return ValueTask.CompletedTask;}

    [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Auto)] private struct MEMORYSTATUSEX{public uint dwLength;public uint dwMemoryLoad;public ulong ullTotalPhys,ullAvailPhys,ullTotalPageFile,ullAvailPageFile,ullTotalVirtual,ullAvailVirtual,ullAvailExtendedVirtual;}
    [DllImport("kernel32.dll",SetLastError=true)] private static extern bool GlobalMemoryStatusExNative(ref MEMORYSTATUSEX lpBuffer);
    private static void GlobalMemoryStatusEx(out MEMORYSTATUSEX m){m=new MEMORYSTATUSEX{dwLength=(uint)Marshal.SizeOf<MEMORYSTATUSEX>()};if(!GlobalMemoryStatusExNative(ref m))m=default;}
    [DllImport("kernel32.dll",SetLastError=true)] private static extern bool GetSystemTimes(out FILETIME idle,out FILETIME kernel,out FILETIME user);
    [StructLayout(LayoutKind.Sequential)] private struct FILETIME{public uint Low,High;public long Ticks=>((long)High<<32)|Low;public static TimeSpan operator -(FILETIME a,FILETIME b)=>TimeSpan.FromTicks(a.Ticks-b.Ticks);}
    private static bool ReadSystemTimes(out TimeSpan idle,out TimeSpan kernel,out TimeSpan user){var ok=GetSystemTimes(out var i,out var k,out var u);idle=TimeSpan.FromTicks(i.Ticks);kernel=TimeSpan.FromTicks(k.Ticks);user=TimeSpan.FromTicks(u.Ticks);return ok;}
}
