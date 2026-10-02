using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Applications;
public sealed record WorkloadProfile(WorkloadKind Kind,string Label,IReadOnlyList<string> ExpectedBehavior,IReadOnlyList<string> Investigate);
public sealed record ApplicationProfile(string Id,string DisplayName,IReadOnlyList<string> ProcessHints,IReadOnlyList<WorkloadProfile> Workloads);
public interface IApplicationProfileProvider{ApplicationProfile GetProfile();}
