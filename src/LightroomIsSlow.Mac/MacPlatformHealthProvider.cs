using LightroomIsSlow.Core.Abstractions;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Mac;
public sealed class MacPlatformHealthProvider:IPlatformHealthProvider
{
 public PlatformHealthSnapshot Capture()=>new(){Platform=PlatformKind.MacOS,CapturedUtc=DateTimeOffset.UtcNow,OsName="macOS",OsVersion=Environment.OSVersion.VersionString,Warnings=["macOS health collection is a Phase 6 scaffold; unavailable measurements remain unknown."]};
}
