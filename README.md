# LightroomIsSlow

LightroomIsSlow is a Windows performance diagnostics project focused on Adobe Lightroom Classic and Lightroom (cloud desktop).

## v0.1.0 goals

- Detect supported Lightroom processes.
- Collect normalized Windows telemetry at a one-second cadence.
- Persist reproducible session data.
- Summarize observed CPU, memory, storage, GPU, network, and Lightroom process behavior.
- Keep diagnosis separate from observation: v0.1.0 reports what happened, not why.

## Guiding principle

> No diagnosis without evidence. No recommendation without a diagnosis. No diagnosis without an explainable rule.

## Repository layout

- `src/LightroomIsSlow.Core` — domain models and collector abstractions.
- `src/LightroomIsSlow.Windows` — Windows-specific discovery and telemetry adapters.
- `src/LightroomIsSlow.Cli` — command-line entry point.
- `tests/LightroomIsSlow.Core.Tests` — core behavior tests.
- `docs` — architecture, telemetry schema, and roadmap.

## Planned CLI

```text
lightroomisslow detect
lightroomisslow record --duration 300
lightroomisslow analyze <session-directory>
```

## Version

Current target: **0.1.0**
