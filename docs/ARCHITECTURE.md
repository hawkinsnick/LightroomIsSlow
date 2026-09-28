# Architecture

## Separation of concerns

LightroomIsSlow is intentionally split into four conceptual layers:

1. **Collection** — obtain raw endpoint and process telemetry.
2. **Normalization** — map source-specific measurements into stable schema fields.
3. **Session** — persist timing, provenance, workload context, and samples.
4. **Analysis** — summarize evidence. Diagnostic rules come later and must remain explainable.

Adobe-specific process knowledge must not leak into generic Windows collector implementations.

## v0.1.0 boundary

v0.1.0 establishes trustworthy observation. It does not yet claim root cause.

The target collection cadence is one sample per second for PerfMon/PDH-style counters. Future ETW-based collectors may operate at different granularities and normalize into the same session model.

## Planned session layout

```text
sessions/<session-id>/
  session.json
  system.json
  telemetry.jsonl
```

Each line of `telemetry.jsonl` is one normalized telemetry sample.
