# Evidence pipeline

LightroomIsSlow separates facts from interpretations.

1. **Measurement** — a collector obtains a native value.
2. **Observation** — the adapter normalizes the value with units, timestamp, source, and measurement status.
3. **Evidence** — a deterministic rule states how one or more observations support, contradict, contextualize, or fail to resolve a hypothesis.
4. **Finding candidate** — a named hypothesis carries evidence and counter-evidence.
5. **Finding** — the engine emits an explainable conclusion with confidence.
6. **Recommendation** — an action is allowed only when tied to a finding or an explicit request for additional evidence.

AI may explain this chain and propose the next discriminating test. AI must not silently replace the chain with an unsupported diagnosis.
