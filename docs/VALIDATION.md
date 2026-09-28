# Validation gates

A 1.0 release is allowed only after:

1. Windows CI restores, builds, and passes all tests.
2. The live collector provides real system CPU, available memory/commit/faults, physical-disk throughput/latency/queue, network throughput, Lightroom process CPU, and supported GPU telemetry or explicitly marks a metric unavailable.
3. A recorded session round-trips through JSONL without schema loss.
4. Evidence rules have positive, negative, and insufficient-evidence tests.
5. No finding is produced solely because a single resource counter is high.
6. At least one real Windows Lightroom Classic trace and one Lightroom cloud-desktop trace are reviewed.
7. Privacy review confirms diagnostic exports do not include image/catalog contents or credentials.

Until these gates pass, the project remains pre-1.0 regardless of feature count.
