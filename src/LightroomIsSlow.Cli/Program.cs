using LightroomIsSlow.Windows.Processes;

var command = args.FirstOrDefault()?.ToLowerInvariant() ?? "help";
var detector = new WindowsLightroomProcessDetector();

switch (command)
{
    case "detect":
        var processes = detector.Detect();
        if (processes.Count == 0)
        {
            Console.WriteLine("No supported Lightroom process detected.");
            return 1;
        }

        foreach (var process in processes)
        {
            Console.WriteLine($"{process.Product}: {process.ProcessName} (PID {process.ProcessId})");
            if (!string.IsNullOrWhiteSpace(process.ProductVersion))
            {
                Console.WriteLine($"  Version: {process.ProductVersion}");
            }
            if (!string.IsNullOrWhiteSpace(process.ExecutablePath))
            {
                Console.WriteLine($"  Path: {process.ExecutablePath}");
            }
        }
        return 0;

    case "record":
        Console.WriteLine("Record pipeline scaffolded in v0.1.0; PDH-backed sampling is the next implementation step.");
        return 2;

    case "analyze":
        Console.WriteLine("Analyze pipeline scaffolded in v0.1.0; descriptive statistics are the next implementation step.");
        return 2;

    default:
        Console.WriteLine("LightroomIsSlow 0.1.0");
        Console.WriteLine("Commands: detect | record | analyze");
        return 0;
}
