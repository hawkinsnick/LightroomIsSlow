# Measurement semantics

## Memory

Windows `Memory\\Page Reads/sec` is a paging-I/O proxy. It is **not** a direct count of hard page faults and must not populate `MemoryHardFaultsPerSecond`.

The normalized model therefore exposes `MemoryPageReadsPerSecond`. A true hard-fault metric remains unavailable until a collector supplies one with defensible provenance (for example through a later ETW implementation).

Memory-pressure diagnosis must not call paging I/O "hard faults." Missing true hard-fault telemetry is unknown, not zero.

## GPU and network

A single arbitrary Performance Counter instance is not sufficient for causal attribution. Collectors should aggregate relevant instances and, where instance naming permits, filter GPU process/engine data to the Lightroom PID. Until attribution is defensible, confidence must remain constrained.

## Storage

PhysicalDisk _Total is system-wide context, not proof that Lightroom caused I/O. Correlation with the marked slowdown and Lightroom activity is required before causal language.
