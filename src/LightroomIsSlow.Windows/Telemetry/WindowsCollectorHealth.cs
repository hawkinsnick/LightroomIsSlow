using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Windows.Telemetry;
public static class WindowsCollectorHealth
{
 public static CollectorHealth Describe(bool hasLightroomProcess)=>new([
 new("cpu.system",MeasurementQuality.Measured,"GetSystemTimes"),
 new("cpu.lightroom",hasLightroomProcess?MeasurementQuality.Attributed:MeasurementQuality.Unavailable,"Process.TotalProcessorTime",hasLightroomProcess?"Bound to detected Lightroom PID":"No Lightroom PID"),
 new("memory.available",MeasurementQuality.Measured,"GlobalMemoryStatusEx"),
 new("memory.page_reads",MeasurementQuality.Contextual,"PerformanceCounter: Memory/Page Reads/sec","System-wide paging I/O proxy; not hard faults"),
 new("storage",MeasurementQuality.Contextual,"PerformanceCounter: PhysicalDisk/_Total","System-wide; correlation is not process attribution"),
 new("gpu",hasLightroomProcess?MeasurementQuality.Attributed:MeasurementQuality.Unavailable,"PerformanceCounter: GPU Engine/GPU Process Memory","Instances filtered to Lightroom PID where Windows exposes PID in instance name"),
 new("network",MeasurementQuality.Contextual,"PerformanceCounter: Network Interface","Aggregated active interfaces; not process-attributed")]);
}
