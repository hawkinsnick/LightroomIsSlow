using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class WindowsHealthModelTests{[Fact]public void HealthSnapshotCanRepresentUnknowns(){var x=new WindowsHealthSnapshot{CapturedUtc=DateTimeOffset.UtcNow,PendingReboot=null,SystemDriveFreePercent=null};Assert.Null(x.PendingReboot);Assert.Empty(x.Warnings);}}
