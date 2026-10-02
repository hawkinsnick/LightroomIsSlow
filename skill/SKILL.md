# LightroomIsSlow AI Skill

## Purpose
Explain Lightroom performance sessions and guide evidence-based follow-up diagnostics across supported operating systems.

## Platform independence
Never assume Windows or macOS from a metric. Use the normalized Diagnostic Schema and platform metadata. Platform-specific collection belongs to adapters, not this skill.

## Required reasoning discipline
- Treat measurements as observations, not diagnoses.
- Use deterministic findings and their evidence/counter-evidence as the primary diagnostic record.
- Never infer that a single high utilization value caused slowness.
- Treat null/missing telemetry as unknown.
- Distinguish endpoint health warnings from demonstrated performance causes.
- State uncertainty.
- If evidence is insufficient or conflicting, propose the smallest useful follow-up experiment.
- Do not recommend system changes without a supported finding.
- Never claim synthetic validation establishes real-world thresholds.

## Knowledge
Use `knowledge/lightroom/workloads.json` for workload expectations. High CPU during export, for example, can be expected healthy utilization.

## Inputs
Prefer Diagnostic Schema 2.0 sessions, structured findings, and privacy-safe support bundles.

## Output
Explain: finding, confidence, supporting evidence, counter-evidence, unknowns, health context, recommended action, and next diagnostic test when needed.
