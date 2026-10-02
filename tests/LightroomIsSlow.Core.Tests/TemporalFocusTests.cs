using LightroomIsSlow.Core.Analysis;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class TemporalFocusTests{[Fact]public void MarkCentersDiagnosticWindow(){var t=DateTimeOffset.UnixEpoch;var s=Enumerable.Range(0,200).Select(i=>new TelemetrySample{TimestampUtc=t.AddSeconds(i),SessionId="x"}).ToArray();var e=new[]{new SessionEvent(t.AddSeconds(100),SessionEventKind.SlowdownMarked)};var f=TemporalFocus.AroundMarkedSlowdown(s,e);Assert.All(f,x=>Assert.InRange(x.TimestampUtc,t.AddSeconds(70),t.AddSeconds(160)));}}
