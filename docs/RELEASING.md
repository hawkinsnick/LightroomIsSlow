# Releasing

The Windows packaging workflow produces a self-contained x64 package so end users do not need to install the .NET SDK.

A tag is not sufficient evidence for a stable release. Before `v1.0.0`, the validation gates in `VALIDATION.md` must pass, including review of real Lightroom Classic and Lightroom desktop traces.

The packaging workflow is intentionally available by manual dispatch before 1.0 so installation and antivirus/SmartScreen behavior can be tested independently of diagnostic validity.
