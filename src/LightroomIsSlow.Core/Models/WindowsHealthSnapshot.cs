namespace LightroomIsSlow.Core.Models;
public sealed record WindowsHealthSnapshot
{
 public required DateTimeOffset CapturedUtc{get;init;}
 public string? WindowsProductName{get;init;} public string? DisplayVersion{get;init;} public string? Build{get;init;}
 public DateTimeOffset? LastBootUtc{get;init;} public bool? PendingReboot{get;init;}
 public DateTimeOffset? LatestInstalledUpdateUtc{get;init;} public int? InstalledUpdateCount{get;init;}
 public string? ActivePowerPlan{get;init;} public double? SystemDriveFreePercent{get;init;}
 public bool? DefenderRealtimeProtectionEnabled{get;init;} public bool? DefenderAntivirusEnabled{get;init;}
 public IReadOnlyList<string> Warnings{get;init;}=[];
}
