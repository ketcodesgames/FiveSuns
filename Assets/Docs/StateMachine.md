
---

# State Machine

## Purpose

In this architecture, the State Machine controls **behavior modes** (Idle, Run, Jump, Fall, Attack, Dash, Stun, etc).
Physics subsystems (Movement2D and Jump2D) control **raw body mechanics** (velocity, impulses, buffering, coyote time, etc).

We separate these two because physics requires exact timing on `FixedUpdate` and gameplay behavior requires logic-based decisions.

---

## Rule

### States trigger events for **high-level behavior**

Events that represent *meaning* belong in states.

Examples:

| Event          | Trigger in State? | Why                                      |
| -------------- | ----------------- | ---------------------------------------- |
| Ground Attack  | YES               | Behavior depends on mode (ground vs air) |
| Aerial Attack  | YES               | Same reason                              |
| Dash Start/End | YES               | Behavior decision                        |
| Enter Stun     | YES               | Behavioral mode                          |
| Death          | YES               | Behavioral mode                          |

States decide which behavior is happening right now.
Therefore, states should trigger those semantic events.

---

### Subsystems trigger events for **raw physical impulses**

Events that represent *pure motion* belong in low-level systems.

Examples:

| Event        | Trigger in Subsystem | Why                                            |
| ------------ | -------------------- | ---------------------------------------------- |
| Jump impulse | Jump2D               | Jump2D knows about buffering/coyote/multi-jump |
| Move         | Movement2D           | Fired every physics tick based on velocity     |
| Flip         | Movement2D           | Discovered via horizontal velocity             |
| Land         | Jump2D / GroundCheck | Based on ground detection physics timing       |

Physics modules already track timing-critical input and constraints.
The State Machine should NOT override or replace that.

---

## Summary Sentence

> ***States = behavior events.***

> ***Subsystems = physics events.***

We keep the system clean by letting each layer own the correct responsibility.

---

## Why this matters

This separation prevents spaghetti code.

If States start firing low-level events, they must reimplement physics timing logic.
If low-level systems start firing behavior events, they must know gameplay context.

By following the rule above, systems stay isolated, and scaling to more complex actions (dash, wall-slide, combos, parries, stun, death) becomes clean and maintainable.

---