# AI skill synchronization

The AI skill lives in the same repository as the application and is built from the same versioned schema and Lightroom knowledge.

`skill/SKILL.md`, `skill/manifest.json`, `schema/`, and `knowledge/` form the portable skill source package.

CI validates and packages the skill on repository updates. This prevents the skill from becoming a separately maintained copy of diagnostic knowledge.

A repository commit is the source of truth. A packaged skill must identify the source commit that produced it. Platform-specific collectors may evolve independently, but changes to normalized contracts or Lightroom diagnostic knowledge must flow through the shared package.
