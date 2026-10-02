namespace LightroomIsSlow.Core.Models;
public enum SessionEventKind{SlowdownMarked,WorkloadStart,WorkloadEnd}
public sealed record SessionEvent(DateTimeOffset TimestampUtc,SessionEventKind Kind,string? Label=null);
