# Cross-platform orchestration — Phases 7 and 8

The user-facing launcher and AI skill invoke semantic diagnostic commands. They do not invoke PDH, WMI, ETW, macOS utilities, or native counter names.

A platform host resolves the appropriate collector and health provider, then writes Diagnostic Schema sessions. The deterministic Core performs analysis. AI explains structured results and may request additional measurements.

The tool vocabulary in `skill/tools.json` is platform independent and mirrors Core orchestration capabilities. A future Windows GUI, macOS app, ChatGPT integration, or other AI host can map these commands to its own authorized execution mechanism.
