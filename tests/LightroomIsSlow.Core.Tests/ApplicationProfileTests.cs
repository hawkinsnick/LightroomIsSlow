using LightroomIsSlow.Core.Applications;
namespace LightroomIsSlow.Core.Tests;
public sealed class ApplicationProfileTests{[Fact]public void LightroomIsAProfileNotTheCoreEngine(){var p=new LightroomApplicationProfile().GetProfile();Assert.Equal("adobe.lightroom",p.Id);Assert.NotEmpty(p.Workloads);}}
