# Windows health context

Windows health is collected as **diagnostic context**, not presumed causality.

Planned/implemented signals include Windows edition/version/build, uptime/last boot, installed-update recency, pending reboot indicators, active power plan, system-drive free capacity, and Microsoft Defender status when readable without changing the machine.

A stale patch level, pending reboot, low disk space, or unusual power configuration may justify a warning or follow-up investigation. None of those facts alone proves that it caused a Lightroom slowdown.

LightroomIsSlow is read-only: it does not install Windows updates, change security settings, alter power plans, run repairs, or modify Lightroom settings.

Future integrity checks may report results from supported Windows servicing/health interfaces, but the application must not silently execute invasive repair operations.
