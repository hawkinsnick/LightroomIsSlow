# Portable diagnostic core

`LightroomIsSlow.Core` owns platform-neutral concepts: normalized telemetry, sessions, workloads, evidence, findings, confidence, reports, validation, and support-bundle contracts.

Platform projects own operating-system APIs and translate them into Core models.

Rules:

- Core must not call Windows, macOS, PDH, ETW, WMI, Registry, PerformanceCounter, or platform security/update APIs.
- Core may identify the source platform as metadata.
- A missing platform measurement is null/unknown, never zero.
- Diagnostic rules operate on normalized semantics rather than native counter names.
- Platform health is context. It is not causal evidence unless a diagnostic rule explicitly correlates it with the measured slowdown.
- Future macOS collectors must implement the same Core contracts without requiring Windows-specific fields.

This boundary lets Windows remain the reference implementation while the diagnostic methodology becomes portable.
