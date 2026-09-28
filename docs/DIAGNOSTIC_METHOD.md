# Diagnostic method

LightroomIsSlow separates **observation**, **evidence**, **finding**, and **recommendation**.

A single high counter value is not itself a bottleneck. Findings require persistence and, where possible, corroborating evidence and available headroom elsewhere.

## Required finding properties

Every diagnostic finding has:
- a stable code;
- human-readable explanation;
- severity;
- confidence;
- supporting evidence;
- counter-evidence;
- zero or more recommendations.

## Conservative outcomes

`INSUFFICIENT_EVIDENCE` is emitted when a session cannot support a defensible inference.

`NO_ENDPOINT_CONSTRAINT` means the collected endpoint telemetry did not establish a sustained constraint. It does **not** mean Lightroom was fast or that no application-level problem existed.

## Initial evidence rules

### STORAGE_PRESSURE
Requires persistent elevated read latency and queueing with CPU headroom.

### MEMORY_PRESSURE
Requires low available memory coincident with hard faults.

### CPU_SATURATION
Requires persistent high CPU utilization. Counter-evidence explicitly notes that saturation may be healthy for CPU-bound Lightroom work.

Thresholds in early releases are hypotheses to validate, not universal hardware truths.
