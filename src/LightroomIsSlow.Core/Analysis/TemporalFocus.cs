using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Analysis;
public static class TemporalFocus
{
 public static IReadOnlyList<TelemetrySample> AroundMarkedSlowdown(IReadOnlyList<TelemetrySample> samples,IReadOnlyList<SessionEvent> events,TimeSpan? before=null,TimeSpan? after=null)
 {
  var mark=events.LastOrDefault(x=>x.Kind==SessionEventKind.SlowdownMarked);if(mark is null)return samples;var b=before??TimeSpan.FromSeconds(30);var a=after??TimeSpan.FromSeconds(60);var start=mark.TimestampUtc-b;var end=mark.TimestampUtc+a;var focused=samples.Where(x=>x.TimestampUtc>=start&&x.TimestampUtc<=end).ToArray();return focused.Length>=10?focused:samples;
 }
}
