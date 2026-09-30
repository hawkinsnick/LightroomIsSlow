using System.IO.Compression;using System.Text.Json;
namespace LightroomIsSlow.Core.Support;
public sealed class SupportBundleBuilder
{
 public string Create(string sessionDirectory){if(!Directory.Exists(sessionDirectory))throw new DirectoryNotFoundException(sessionDirectory);var id=Path.GetFileName(Path.GetFullPath(sessionDirectory).TrimEnd(Path.DirectorySeparatorChar));var outPath=Path.Combine(Path.GetDirectoryName(Path.GetFullPath(sessionDirectory))!,$"{id}-support.zip");if(File.Exists(outPath))File.Delete(outPath);var manifest=new SupportBundleManifest("1",id,DateTimeOffset.UtcNow,"Contains diagnostic telemetry and metadata. It must not contain photographs, catalog contents, credentials, or cloud tokens.");File.WriteAllText(Path.Combine(sessionDirectory,"support-manifest.json"),JsonSerializer.Serialize(manifest,new JsonSerializerOptions{WriteIndented=true}));using var zip=ZipFile.Open(outPath,ZipArchiveMode.Create);foreach(var name in new[]{"session.json","telemetry.jsonl","report.md","support-manifest.json"}){var p=Path.Combine(sessionDirectory,name);if(File.Exists(p))zip.CreateEntryFromFile(p,name,CompressionLevel.Optimal);}return outPath;}
}
