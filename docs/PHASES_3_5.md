# Phases 3 through 5

## Phase 3 — Formal telemetry contract
Diagnostic Schema 2.0 is the platform-independent interchange boundary. Native Windows/macOS counters are adapter concerns.

## Phase 4 — Observation and evidence separation
The portable Core represents normalized observations, evidence disposition, counter-evidence, hypotheses, confidence, findings, and recommendations as distinct concepts.

## Phase 5 — Lightroom knowledge and AI skill
Lightroom workload expectations are data in `knowledge/`. The AI skill consumes shared schema and knowledge rather than duplicating them.

## Continuous synchronization
Every push to the repository triggers the portable skill build. The artifact includes a `SOURCE_COMMIT` file so a skill package can be traced to the exact Git commit that generated it.

This means repository changes automatically produce a new validated skill artifact. Distribution into a particular AI product may still require that product's install/update mechanism; repository CI cannot silently replace an installed third-party skill unless that platform exposes and authorizes such deployment.
