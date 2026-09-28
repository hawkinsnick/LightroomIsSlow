# LightroomIsSlow

**“Why is Lightroom so slow?” — let’s measure it.**

LightroomIsSlow is a Windows performance diagnostic tool for **Adobe Lightroom Classic** and **Adobe Lightroom (desktop/cloud)**. It records endpoint performance while you reproduce a slowdown, then analyzes the evidence instead of guessing from a single CPU, memory, disk, or GPU number.

> **Project status: pre-1.0 / testing.** The diagnostic engine and Windows telemetry pipeline are under active validation. Results should not yet be treated as production support guidance.

## For photographers and non-technical testers

You should **not need to understand the source code** to help test LightroomIsSlow.

### Easiest method — downloadable Windows build

Our 1.0 target is:

1. Open this repository's **Releases** page.
2. Download the Windows release package.
3. Extract it to a folder.
4. Start Lightroom.
5. Double-click the LightroomIsSlow launcher.
6. Click/start **Record**, reproduce the Lightroom slowdown, then stop recording.
7. Run **Analyze**.
8. Share the resulting diagnostic report if you are helping us test.

**Important:** a public end-user release package is not published yet. Do not download random executables claiming to be LightroomIsSlow. Official builds will be linked from this repository's Releases page.

See [docs/USER_GUIDE.md](docs/USER_GUIDE.md) for the complete walkthrough.

## Developer / early tester method

Until packaged Windows builds are published, running from source requires Windows and the .NET 8 SDK:

```powershell
git clone https://github.com/hawkinsnick/LightroomIsSlow.git
cd LightroomIsSlow
dotnet restore LightroomIsSlow.slnx
dotnet build LightroomIsSlow.slnx -c Release
dotnet run --project src/LightroomIsSlow.Cli -- detect
dotnet run --project src/LightroomIsSlow.Cli -- record --duration 300
dotnet run --project src/LightroomIsSlow.Cli -- analyze sessions\<session-folder>
```

This path is intended for developers and technically comfortable testers.

## What it measures

The architecture supports normalized observations for CPU, Lightroom process CPU, memory/commit pressure, memory faults, disk throughput/latency/queueing, network throughput, GPU activity/VRAM where exposed by Windows, hardware inventory, and metric provenance.

Unavailable measurements are recorded as unavailable — **never silently converted to zero**.

## Diagnostic philosophy

> **No diagnosis without evidence. No recommendation without a diagnosis. No diagnosis without an explainable rule.**

High resource utilization alone is not automatically a bottleneck. LightroomIsSlow is designed to consider persistence, corroborating measurements, available headroom, workload context, and counter-evidence.

It can also conclude **INSUFFICIENT_EVIDENCE** or **NO_ENDPOINT_CONSTRAINT** rather than inventing an explanation.

## Privacy

LightroomIsSlow is designed for local endpoint diagnosis. It should not collect photographs, image contents, Lightroom catalog contents, account credentials, or cloud tokens. See [PRIVACY.md](PRIVACY.md).

## Documentation

- [User Guide](docs/USER_GUIDE.md)
- [Architecture](docs/ARCHITECTURE.md)
- [Diagnostic Method](docs/DIAGNOSTIC_METHOD.md)
- [Telemetry Schema](docs/TELEMETRY_SCHEMA.md)
- [Collector Coverage](docs/COLLECTORS.md)
- [Validation Gates](docs/VALIDATION.md)
- [Roadmap](docs/ROADMAP.md)

## Version

Current development line: **0.9.x pre-1.0 validation**
