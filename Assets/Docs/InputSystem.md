# Input System Documentation

## Current Implementation

### Overview
Tona Maqui uses Unity's new Input System with an event-driven architecture to handle player input. The system is designed to be modular and extensible, following our feature-based architecture.

### Core Components

#### 1. InputReader (Core Component)
Located in `Core/Input/InputReader.cs`, this component:
- Handles raw input detection using Unity's new Input System
- Broadcasts input events to interested components
- Manages input action references and callbacks

#### 2. Input Constants
Located in `Core/Utilities/Constants.cs`, defines:
```csharp
public static class InputActions
{
    public const string Move = "Move";
    public const string Jump = "Jump";
}
```

### Current Action Maps
- **Gameplay**: Basic movement and actions
  - Move (Vector2)
  - Jump (Button)

## Future Enhancements

### 1. Extended Action Maps
We should consider adding the following action maps:

#### Combat
```
combat/
├── attack
├── block
├── dodge
└── special
```

#### UI/Menu
```
ui/
├── navigate
├── confirm
├── cancel
└── pause
```

#### Abilities
```
abilities/
├── dash
├── power1
├── power2
└── ultimate
```

### 2. Input Context Management
Future implementation should include:

```csharp
public class InputManager : MonoBehaviour
{
    public enum InputContext
    {
        Gameplay,
        Combat,
        UI,
        Cinematic
    }
    
    // Methods to switch between contexts
    public void SwitchContext(InputContext context);
    public void PushContext(InputContext context);
    public void PopContext();
}
```

### 3. Feature-Specific Input Readers
As features grow, consider splitting input handling:

```
Core/Input/
├── GameplayInputReader.cs    // Core movement
├── CombatInputReader.cs      // Combat actions
└── UIInputReader.cs         // Menu navigation
```

### 4. Input Buffer System
Future implementation should include:

- Buffer window for actions (configurable per action)
- Input queuing for combat combinations
- Input priority system

### 5. Device-Specific Considerations

#### Keyboard/Mouse
- Rebindable keys
- Different keyboard layouts
- Mouse sensitivity settings

#### Gamepad
- Multiple gamepad support
- Vibration feedback
- Analog stick dead zones

#### Touch Controls (Future)
- Virtual joystick
- Gesture recognition
- Dynamic button placement

## Best Practices

1. **Action Organization**
   - Keep action names consistent with `Constants.InputActions`
   - Group related actions in appropriate action maps
   - Use meaningful action names

2. **Event Handling**
   - Subscribe/unsubscribe in OnEnable/OnDisable
   - Use appropriate event parameters
   - Consider input buffering for tight timing

3. **Input Context**
   - Clear state management
   - Handle transitions smoothly
   - Consider overlapping contexts

4. **Performance**
   - Cache action references
   - Use event pooling for frequent events
   - Minimize garbage collection

## Migration Guide

When adding new input actions:

1. Add constants to `Constants.InputActions`
2. Add events to appropriate InputReader
3. Implement handlers in feature components
