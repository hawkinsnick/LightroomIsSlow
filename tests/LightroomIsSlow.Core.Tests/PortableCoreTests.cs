using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Tests;
public sealed class PortableCoreTests
{
 [Fact]public void PlatformHealthCanRepresentMacWithoutWindowsConcepts(){var h=new PlatformHealthSnapshot{Platform=PlatformKind.MacOS,CapturedUtc=DateTimeOffset.UtcNow,OsName="macOS",OsVersion="unknown",PendingRestart=null};Assert.Equal(PlatformKind.MacOS,h.Platform);Assert.Null(h.PendingRestart);}
 [Fact]public void PlatformHealthPreservesUnknownMeasurements(){var h=new PlatformHealthSnapshot{Platform=PlatformKind.Windows,CapturedUtc=DateTimeOffset.UtcNow,SystemDriveFreePercent=null};Assert.Null(h.SystemDriveFreePercent);}
}
