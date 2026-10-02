# Phases 1 and 2

## Phase 1 — Windows reference implementation

Exit criteria:
- Windows solution builds and tests in CI.
- End-user GUI requires no terminal for the normal workflow.
- Lightroom detection, recording, automatic analysis, reports, Windows health context, and privacy-safe support bundles are integrated.
- Self-contained Windows packaging succeeds.
- Missing optional telemetry fails gracefully.
- Real Lightroom traces remain the external-validity gate for a stable 1.0 diagnosis claim.

## Phase 2 — Portable diagnostic core

Exit criteria:
- Core contains no operating-system API calls.
- Platform collectors implement Core contracts.
- Session metadata uses platform-neutral health and provenance models.
- Diagnostic rules consume normalized telemetry only.
- Synthetic validation runs independently of Windows collectors.
- macOS can be added as a new adapter without changing the diagnostic contract.

Windows is the reference collector, not the definition of the diagnostic model.
