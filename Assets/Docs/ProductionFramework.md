# Production Framework (micro)

Each feature, system, or asset passes through the same four phases: **Concept → Prototype → Production → Polish**. Each phase synchronizes with one Jira epic **(Game Design, Engineering, Art, Story, Audio, Marketing)**.

## PHASE I – Concept & Foundation
**Goal: Define what it is, why it exists, and how it fits into the game.**

| Epic                    | Typical Tasks                                                                                        | Deliverables                    |
| ----------------------- | ---------------------------------------------------------------------------------------------------- | ------------------------------- |
| **Story & Writing**     | Define narrative function (context, lore tie-in, dialogue hooks).                                    | Narrative Brief                 |
| **Game Design**         | Identify gameplay purpose (challenge, mechanic, or reward). Draft concept sketch or feature summary. | Mini GDD entry                  |
| **Engineering**         | Plan technical approach and dependencies. Estimate time/cost.                                        | Technical Design Sheet          |
| **Art & Animation**     | Create early concept art, moodboard, or reference sheet.                                             | Concept Sheet                   |
| **Audio**               | Describe intended tone (ambient, aggressive, peaceful, etc.).                                        | Sound Concept Reference         |
| **Marketing/Community** | Optionally log internal dev update or teaser concept.                                                | Devlog Note (optional)          |


📤 Output:

- Feature Pitch approved
- Clear goals and scope defined
- Jira tasks created under corresponding epic

## PHASE II – Prototype & Systems
**Goal: Build a playable or functional minimum version that proves the idea works.**

| Epic                    | Typical Tasks                                                                 | Deliverables           |
| ----------------------- | ----------------------------------------------------------------------------- | ---------------------- |
| **Game Design**         | Tune core parameters, test mechanic feel, document insights.                  | Prototype Design Notes |
| **Engineering**         | Implement first iteration (stub or simplified logic). Integrate input/events. | Prototype Build        |
| **Art & Animation**     | Use placeholder art or basic animation pass.                                  | Prototype Visuals      |
| **Story & Writing**     | Add placeholder text or dialogue for context testing.                         | Narrative Prototype    |
| **Audio**               | Add temp SFX or background track for feel validation.                         | Prototype Audio Layer  |
| **Marketing/Community** | Optional: internal clip or GIF for morale/devlog.                             | Early Preview Clip     |


📤 Output:

- Playable prototype
- Core mechanic validated
- Feedback collected

## PHASE III – Content Production
**Goal: Build the final, complete version of the feature with all content layers.**

| Epic                    | Typical Tasks                                                                    | Deliverables          |
| ----------------------- | -------------------------------------------------------------------------------- | --------------------- |
| **Game Design**         | Integrate feature into level loop or progression. Balance numbers and pacing.    | Final Design Sheet    |
| **Engineering**         | Implement full functionality, handle edge cases, connect to save/events systems. | Production-Ready Code |
| **Art & Animation**     | Replace placeholders with final assets (sprites, VFX, UI).                       | Final Art Assets      |
| **Story & Writing**     | Finalize text, cutscene script, codex entry, or dialogue.                        | Final Script          |
| **Audio**               | Implement final SFX/music and mix levels.                                        | Final Sound Layer     |
| **Marketing/Community** | Create visuals or clips for marketing or progress updates.                       | Showcase Asset        |


📤 Output:

- Fully functional feature
- Integrated with other systems
- Ready for QA
- PHASE IV – Polish & QA

## PHASE IV – Polish
**Goal: Refine, fix, and balance everything for a release-quality result.**

| Epic                    | Typical Tasks                                                    | Deliverables        |
| ----------------------- | ---------------------------------------------------------------- | ------------------- |
| **Game Design**         | Adjust tuning, difficulty, responsiveness, pacing.               | Final Balance Notes |
| **Engineering**         | Optimize performance, clean code, fix bugs.                      | Stable Build        |
| **Art & Animation**     | Add FX polish, lighting, color correction, transition smoothing. | Polished Art Pass   |
| **Story & Writing**     | Proofread text, localization, consistency checks.                | Approved Narrative  |
| **Audio**               | Final mix/master and sync verification.                          | Final Mix           |
| **Marketing/Community** | Publish post, trailer, or BTS content related to this feature.   | Published Update    |


📤 Output:

- QA-approved, optimized feature
- Tagged as “Ready for Release”


## 🧭 HOW TO USE IT

- Choose a target scope — e.g. “Player Character,” “Forest Biome,” “Combat System,” “First Boss.”
- Duplicate this framework as a checklist in your design doc or Jira.
- Tag all subtasks with the same label (feature:forest_boss, phase-II, etc.).
- Work phase by phase, ensuring each step produces visible output before moving forward.
- Integrate feedback loops at the end of Phase II and Phase IV for playtesting.

## ⚔️ Example Use Case — Main Character (Tōna)

Demonstrates how this framework applies to a concrete feature.

| Phase                       | Summary                                                                                                                                                                             | Key Outputs                                      |
| --------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------ |
| **I. Concept & Foundation** | Define Tōna’s identity and gameplay purpose. Story: false sun tied to Mictlán; Design: agile melee archetype; Art: finalize concept sheets; Engineering: set up prefab + input map. | Character Design Doc, Concept Art, Input Plan    |
| **II. Prototype & Systems** | Implement movement controller with coyote time, jump, and attack. Tune feel and responsiveness; use placeholder animations.                                                         | Playable Prototype, Movement Tuning Sheet        |
| **III. Content Production** | Add final animations (run, jump, roll, parry, death), integrate ability tree, link to stamina/energy, finalize FX.                                                                  | Full Character Prefab, Final Art & Animation Set |
| **IV. Polish & QA**         | Optimize state transitions, polish lighting, rebalance cooldowns, finalize audio mix.                                                                                               | Gold-Ready Character, Showcase Clip              |


📤 End Result:
A complete, production-ready main character module that can plug directly into your game’s systems — built through a repeatable, documented process.