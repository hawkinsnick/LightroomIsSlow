# Synthetic validation laboratory

Synthetic traces are deterministic fixtures used to test diagnostic logic before real Lightroom traces are available.

They are **not evidence that thresholds are correct for real Lightroom workloads**. They test internal consistency: a rule should fire when its stated evidence exists and remain silent when evidence is absent.

Current fixtures cover healthy telemetry, storage pressure, memory pressure, CPU saturation, and missing counters.

The suite will expand with boundary values, short spikes, contradictory evidence, mixed constraints, intermittent stalls, counter dropout, implausible values, and workload-specific healthy saturation.

Real traces remain necessary to calibrate thresholds and establish external validity.
