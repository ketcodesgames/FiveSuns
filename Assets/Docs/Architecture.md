---

## 🧠 Core Principles

This structure uses a **feature-based, scalable architecture** — common in large Unity studios (e.g., Hollow Knight, Ori, Dead Cells, Blasphemous teams).

* **Feature-based separation** → everything related to “Player” lives in `Features/Player/`.
* **Core is sacred** → systems shared across the game go in `/Core`.
* **Independent modules** → easy to move, refactor, or package later.
* **Progressive layers** → start lightweight, then evolve into a package-based or addressable-based setup when needed.
* **Minimal dependencies** → avoid spaghetti between features (use events, interfaces, or dependency injection).

---

## 🏗️ FINAL ENTERPRISE-READY STRUCTURE

```
Assets/
 ┣ Art/
 ┃ ┣ Characters/
 ┃ ┣ Environment/
 ┃ ┣ FX/
 ┃ ┗ UI/
 ┣ Audio/
 ┃ ┣ Music/
 ┃ ┗ SFX/
 ┣ Core/
 ┃ ┣ Boot/
 ┃ ┣ Input/
 ┃ ┣ SaveSystem/
 ┃ ┣ Events/
 ┃ ┣ SceneManagement/
 ┃ ┣ Services/
 ┃ ┗ Utilities/
 ┣ Features/
 ┃ ┣ Player/
 ┃ ┣ Enemies/
 ┃ ┣ Abilities/
 ┃ ┣ Items/
 ┃ ┣ Combat/
 ┃ ┣ World/
 ┃ ┗ UI/
 ┣ Scenes/
 ┃ ┣ Bootstrap/
 ┃ ┣ Levels/
 ┃ ┗ UI/
 ┣ Prefabs/
 ┃ ┣ Gameplay/
 ┃ ┣ Environment/
 ┃ ┗ UI/
 ┣ UI/
 ┃ ┣ HUD/
 ┃ ┣ Menus/
 ┃ ┗ Dialogs/
 ┣ Scripts/
 ┣ Tests/
 ┣ Editor/
 ┣ Packages/
 ┗ Docs/
```

We’ll explain this below — but you won’t start with all of this.

---

## ⚙️ PHASE 1 — Start Small (Initial Setup)

When you first start the project, **don’t over-engineer**.
Start with this simplified layout and grow it later:

```
Assets/
 ┣ Core/
 ┣ Features/
 ┃ ┣ Player/
 ┃ ┣ Enemies/
 ┣ Scenes/
 ┣ Prefabs/
 ┣ Art/
 ┣ Audio/
 ┣ UI/
```

This lets you focus on building the foundation (movement, camera, level transitions) without noise.

Later (Phase 2–3), you’ll expand to the full enterprise architecture above.

---

## 📁 Folder Explanations + Examples

---

### 🧩 **Core/**

**Purpose:** The backbone of your game — systems used by *everything*.
Should be small, clean, and independent of gameplay specifics.

**Subfolders & Examples:**

| Subfolder            | Purpose                     | Examples                                                           |
| -------------------- | --------------------------- | ------------------------------------------------------------------ |
| **Boot/**            | Entry point, initialization | `Bootstrap.cs` (loads services, managers, first scene)             |
| **Input/**           | Input handling              | `InputReader.cs` (Unity InputSystem wrapper), `PlayerInputActions` |
| **SaveSystem/**      | Saving/loading              | `SaveManager.cs`, `SaveData.cs`                                    |
| **Events/**          | Global event system         | `GameEvent.cs`, `EventBus.cs`                                      |
| **SceneManagement/** | Scene loading, transitions  | `SceneLoader.cs`, `LoadingScreen.cs`                               |
| **Services/**        | Common global services      | `AudioService.cs`, `UIService.cs`, `LocalizationService.cs`        |
| **Utilities/**       | Small helpers               | `Timer.cs`, `MathHelpers.cs`                                       |

**Example:**
`Core/Boot/Bootstrap.cs`

```csharp
public class Bootstrap : MonoBehaviour {
    async void Start() {
        ServiceLocator.Initialize();
        await SceneLoader.LoadAsync("MainMenu");
    }
}
```

---

### ⚔️ **Features/**

**Purpose:** Group all gameplay logic by feature — not by type.
Each feature contains everything it needs: scripts, prefabs, animations, data, etc.

**Structure:**

```
Features/
 ┣ Player/
 ┃ ┣ Scripts/
 ┃ ┣ Data/
 ┃ ┣ Prefabs/
 ┃ ┗ Animations/
 ┣ Enemies/
 ┃ ┣ Common/
 ┃ ┗ SpecificEnemyA/
 ┣ Abilities/
 ┣ Items/
 ┣ Combat/
 ┗ World/
```

**Examples:**

`Features/Player/Scripts/PlayerController.cs`
→ movement, jumping, dashing.

`Features/Player/Data/PlayerStats.asset`
→ ScriptableObject with HP, speed, jump force.

`Features/Enemies/Common/EnemyAIBase.cs`
→ reusable AI logic.

`Features/Abilities/DashAbility.cs`
→ ScriptableObject ability that modifies player motion.

**Why:**
Keeps features self-contained and modular. Easy to split into packages later or delegate to teams.

---

### 🎨 **Art/**

**Purpose:** Raw art assets, separated from code.

**Examples:**

* `Art/Characters/Player/Idle_0.png`
* `Art/Environment/Tilesets/Temple.png`
* `Art/FX/HitEffect.png`

Avoid mixing `.cs` or prefabs here — art is only for sprites, textures, animations.

---

### 🔊 **Audio/**

**Purpose:** Music, sound effects, ambient loops.

**Examples:**

* `Audio/Music/OverworldTheme.ogg`
* `Audio/SFX/SwordSlash.wav`
* `Audio/SFX/UI_Click.wav`

---

### 🧱 **Prefabs/**

**Purpose:** Prefabs shared across the project.
Specific prefabs (like the player) stay in their feature folders.

**Examples:**

* `Prefabs/Gameplay/Checkpoint.prefab`
* `Prefabs/Environment/Platform.prefab`
* `Prefabs/UI/DialogueBox.prefab`

---

### 🎮 **Scenes/**

**Purpose:** Organize all Unity scenes.

| Folder         | Purpose                                    | Examples                                        |
| -------------- | ------------------------------------------ | ----------------------------------------------- |
| **Bootstrap/** | Initial boot scene (load managers, config) | `Init.unity`                                    |
| **Levels/**    | Game levels                                | `Level_01_Temple.unity`, `Level_02_Caves.unity` |
| **UI/**        | Menus and overlays                         | `MainMenu.unity`, `PauseMenu.unity`             |

---

### 🖥️ **UI/**

**Purpose:** All interface assets — HUD, menus, dialogues.

**Examples:**

* `UI/HUD/HealthBar.prefab`, `StaminaBar.prefab`
* `UI/Menus/MainMenu.prefab`, `PauseMenu.prefab`
* `UI/Dialogs/NPCDialogue.prefab`, `DialogueData.asset`

Later, this may be moved under `Features/UI/` when you start modularizing the UI logic.

---

### 🧠 **Scripts/**

**Purpose:** Temporary place for general scripts that don’t belong anywhere yet.
Over time, move them into their correct `Core` or `Features` folders.

---

### 🧰 **Editor/**

**Purpose:** Custom editor tools, inspectors, or level-building utilities.

**Examples:**

* `Editor/DialogueEditorWindow.cs`
* `Editor/LevelImporter.cs`

---

### 🧪 **Tests/**

**Purpose:** Automated tests.

**Examples:**

* `Tests/EditMode/PlayerMovementTests.cs`
* `Tests/PlayMode/CombatIntegrationTests.cs`

---

### 📦 **Packages/**

**Purpose:** Used later when your project grows and you want to separate features into modular Unity packages.

**Examples:**

* `Packages/com.tahue.features.combat/`
* `Packages/com.tahue.features.inventory/`

---

### 📜 **Docs/**

**Purpose:** Internal documentation (architecture decisions, conventions, style guides, etc.)

**Examples:**

* `Docs/Architecture.md`
* `Docs/CodingConventions.md`
* `Docs/DesignRules.md`

---

## 🔁 PHASED GROWTH PLAN

| Phase                 | Goal                         | What to Add                                                   |
| --------------------- | ---------------------------- | ------------------------------------------------------------- |
| **1. Prototype**      | Core gameplay foundation     | `/Core`, `/Features`, `/Scenes`, `/Art`, `/Audio`, `/Prefabs` |
| **2. Pre-production** | Add tools & structure        | `/Editor`, `/UI`, `/Docs`, `/Tests`                           |
| **3. Production**     | Modularization, addressables | `/Packages`, `/Services`, `/Localization`                     |
| **4. Post-launch**    | Modding & live content       | Addressables, content pipelines, analytics services           |

---

## 🧩 BONUS — Architectural Pattern Summary

| Pattern                        | Purpose                     | Example                                          |
| ------------------------------ | --------------------------- | ------------------------------------------------ |
| **Event Bus / Message System** | Decouple systems            | Player publishes `OnPlayerDamaged` → HUD listens |
| **ScriptableObjects as Data**  | Designer-friendly data      | Abilities, stats, enemies                        |
| **State Machines**             | Clean behavior              | PlayerStateMachine: Idle, Jump, Dash             |
| **DI / Service Locator**       | Modular service access      | `SaveService`, `AudioService`, etc.              |
| **Scene Composition**          | Bootstrap + additive levels | Persistent world manager scene                   |
| **Feature-Based Foldering**    | Scalable modularity         | `Features/Player`, `Features/Combat`             |

---

## ✅ TL;DR — Start with this (Phase 1)

```
Assets/
 ┣ Core/
 ┣ Features/
 ┃ ┣ Player/
 ┃ ┗ Enemies/
 ┣ Scenes/
 ┣ Prefabs/
 ┣ Art/
 ┣ Audio/
 ┗ UI/
```

Then, as systems grow:
→ add `/Services`, `/Packages`, `/Editor`, `/Tests`, `/Docs`.

---

Would you like me to show you a **ready-to-use folder setup script** (an Editor script that automatically creates all these folders in your Unity project)?
That way, you can run it once and start clean with the exact structure.
