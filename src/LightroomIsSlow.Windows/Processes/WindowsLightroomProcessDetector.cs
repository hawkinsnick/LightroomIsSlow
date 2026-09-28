using System.Diagnostics;
using LightroomIsSlow.Core.Abstractions;
using LightroomIsSlow.Core.Models;

namespace LightroomIsSlow.Windows.Processes;

public sealed class WindowsLightroomProcessDetector : ILightroomProcessDetector
{
    public IReadOnlyList<ProcessIdentity> Detect()
    {
        var results = new List<ProcessIdentity>();

        foreach (var process in Process.GetProcesses())
        {
            try
            {
                var product = Classify(process.ProcessName);
                if (product == LightroomProduct.Unknown)
                {
                    continue;
                }

                string? path = null;
                string? version = null;

                try
                {
                    path = process.MainModule?.FileName;
                    version = process.MainModule?.FileVersionInfo.ProductVersion;
                }
                catch
                {
                    // Path/version may be unavailable under restricted permissions.
                }

                results.Add(new ProcessIdentity(process.Id, process.ProcessName, product, path, version));
            }
            finally
            {
                process.Dispose();
            }
        }

        return results.OrderBy(x => x.Product).ThenBy(x => x.ProcessId).ToArray();
    }

    internal static LightroomProduct Classify(string processName)
    {
        if (processName.Equals("Lightroom", StringComparison.OrdinalIgnoreCase))
        {
            return LightroomProduct.Classic;
        }

        if (processName.Equals("Adobe Lightroom", StringComparison.OrdinalIgnoreCase) ||
            processName.Equals("LightroomCC", StringComparison.OrdinalIgnoreCase))
        {
            return LightroomProduct.CloudDesktop;
        }

        return LightroomProduct.Unknown;
    }
}
