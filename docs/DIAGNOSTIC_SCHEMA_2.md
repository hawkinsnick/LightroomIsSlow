# Diagnostic Schema 2.0

The schema is the interoperability boundary between collectors, the deterministic diagnostic engine, and AI skills.

Native platform counter names never appear in diagnostic rules. Adapters normalize them into semantic measurements such as storage latency, application CPU, memory pressure proxies, GPU activity, and network throughput.

The JSON Schemas in `schema/` are platform independent. Windows and macOS may have different measurement availability; unavailable values remain null or absent. They are never synthesized as zero.

Schema evolution follows explicit versions. AI skill packages declare which schema versions they understand.
