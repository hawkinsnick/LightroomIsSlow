# Application profiles — Phase 12

The endpoint diagnostic engine is reusable; application knowledge is supplied by profiles.

Lightroom remains the only supported application profile today. The generic boundary exists so future applications can reuse normalized telemetry, evidence, baselines, experiments, reports, and AI orchestration without copying the engine.

Creating the abstraction does not imply validated support for Photoshop, Premiere, Capture One, DaVinci Resolve, or any other product. Each future profile requires its own process detection, workload knowledge, diagnostic rules, synthetic tests, and real-world validation.
