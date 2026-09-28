using System.Text.Json;
using System.Text.Json.Serialization;

namespace LightroomIsSlow.Core.Serialization;

public static class SessionJson
{
    public static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}
