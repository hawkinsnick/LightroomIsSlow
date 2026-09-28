using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Tests;

public sealed class TelemetrySampleTests
{
    [Fact]
    public void SampleCarriesSessionAndTimestamp()
    {
        var now = DateTimeOffset.UtcNow;
        var sample = new TelemetrySample { SessionId = "session-1", TimestampUtc = now };

        Assert.Equal("session-1", sample.SessionId);
        Assert.Equal(now, sample.TimestampUtc);
    }
}
