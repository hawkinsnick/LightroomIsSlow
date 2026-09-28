# Roadmap

## 0.1.0 — Observation foundation
- Repository architecture
- Lightroom Classic / Cloud process discovery
- Normalized telemetry schema
- Session metadata model
- Windows collector abstraction
- CLI shell
- Core tests

## 0.1.x — Complete collection pipeline
- Native PDH interop
- CPU, memory, disk, network counters
- GPU counter discovery and normalization
- One-second scheduler with dropped-sample accounting
- JSONL session writer
- Endpoint hardware inventory
- Descriptive analysis and percentiles

## 0.2.0 — First evidence rules
- Storage-pressure evidence
- Memory-pressure evidence
- CPU saturation evidence
- GPU saturation/VRAM evidence
- Network/cloud evidence
- Confidence and severity semantics

No rule may emit a recommendation without exposing the observations that triggered it.
