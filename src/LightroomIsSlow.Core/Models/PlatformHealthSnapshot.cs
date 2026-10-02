namespace LightroomIsSlow.Core.Models;
public sealed record PlatformHealthSnapshot
{
 public required PlatformKind Platform{get;init;}
 public required DateTimeOffset CapturedUtc{get;init;}
 public string? OsName{get;init;} public string? OsVersion{get;init;} public string? OsBuild{get;init;}
 public DateTimeOffset? LastBootUtc{get;init;} public bool? PendingRestart{get;init;}
 public DateTimeOffset? LatestInstalledUpdateUtc{get;init;} public int? InstalledUpdateCount{get;init;}
 public string? PowerMode{get;init;} public double? SystemDriveFreePercent{get;init;}
 public IReadOnlyDictionary<string,string?> SecurityState{get;init;}=new Dictionary<string,string?>();
 public IReadOnlyList<string> Warnings{get;init;}=[];
}
