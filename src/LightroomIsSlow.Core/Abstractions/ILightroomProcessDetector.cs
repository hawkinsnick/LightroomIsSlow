using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Core.Abstractions;

public interface ILightroomProcessDetector
{
    IReadOnlyList<ProcessIdentity> Detect();
}
