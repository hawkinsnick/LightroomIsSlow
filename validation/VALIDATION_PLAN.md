# Validation plan

## Questions

1. Does a rule fire when its intended bottleneck pattern is present?
2. Does it remain silent when only one supporting signal is high?
3. Does the finding overlap the user-marked slowdown?
4. Is the same pattern reproducible?
5. How often does the engine disagree with blinded human observation?
6. How often is telemetry unavailable or merely contextual?

## Dataset separation

Keep threshold-development traces separate from final evaluation traces. Do not repeatedly tune on the same sessions used to claim performance.

## Metrics

Track finding-level true positives, false positives, false negatives, inconclusive sessions, telemetry coverage, and confidence calibration. Report sample counts with every rate.

## Release gate

Do not call thresholds externally validated until representative real traces exist across multiple machines, Lightroom versions, workloads, storage configurations, memory capacities, and GPU vendors.
