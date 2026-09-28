namespace LightroomIsSlow.Core.Models;

public sealed record ProcessIdentity(
    int ProcessId,
    string ProcessName,
    LightroomProduct Product,
    string? ExecutablePath = null,
    string? ProductVersion = null);
