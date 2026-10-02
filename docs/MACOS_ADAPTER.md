# macOS adapter — Phase 6

The macOS project proves the platform boundary by implementing Core interfaces without referencing Windows.

The initial adapter is intentionally conservative: unsupported measurements are null. It does not fabricate parity with Windows counters.

Next collector work should map macOS-native CPU, memory pressure, storage I/O, GPU, network, update, power, and process telemetry into the existing normalized schema. Native details remain inside this adapter.

A scaffold is not empirical validation. Real macOS Lightroom traces remain required before macOS diagnostic claims can be considered validated.
