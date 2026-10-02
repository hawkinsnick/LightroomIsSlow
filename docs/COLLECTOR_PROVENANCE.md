# Collector provenance and self-health

Each measurement has a quality class:

- **Unavailable** — no defensible value was collected.
- **Contextual** — measured at system/device level but not attributed to Lightroom.
- **Measured** — direct measurement of the stated system quantity.
- **Attributed** — measurement is associated with the detected Lightroom process.

Diagnostic language must not outrun this quality. In particular, system-wide disk or network activity can corroborate a marked slowdown but cannot by itself prove Lightroom caused that activity.

Collector health is separate from endpoint health. A missing GPU counter means "GPU telemetry unavailable," not "GPU healthy."
