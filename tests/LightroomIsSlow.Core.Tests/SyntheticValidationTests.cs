using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Validation;
namespace LightroomIsSlow.Core.Tests;
public sealed class SyntheticValidationTests
{
 private readonly DiagnosticEngine e=new();
 [Fact]public void HealthyHasNoConstraint()=>Assert.Contains(e.Evaluate(SyntheticTraceFactory.Healthy()),x=>x.Code=="NO_ENDPOINT_CONSTRAINT");
 [Fact]public void StorageIsDetected()=>Assert.Contains(e.Evaluate(SyntheticTraceFactory.StoragePressure()),x=>x.Code=="STORAGE_PRESSURE");
 [Fact]public void MemoryIsDetected()=>Assert.Contains(e.Evaluate(SyntheticTraceFactory.MemoryPressure()),x=>x.Code=="MEMORY_PRESSURE");
 [Fact]public void CpuIsDetected()=>Assert.Contains(e.Evaluate(SyntheticTraceFactory.CpuBound()),x=>x.Code=="CPU_SATURATION");
 [Fact]public void MissingCountersDoNotBecomeStoragePressure()=>Assert.DoesNotContain(e.Evaluate(SyntheticTraceFactory.MissingCounters()),x=>x.Code=="STORAGE_PRESSURE");
}
