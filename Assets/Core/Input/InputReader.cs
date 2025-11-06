using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.Burst.CompilerServices;

public class InputReader : MonoBehaviour
{
    // Player Input
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;

    // Movement Input
    public Vector2 MoveInput { get; private set; }
    public event Action<Vector2> OnMovePerformed;
    public event Action OnMoveStarted;
    public event Action OnMoveCanceled;

    // Jump Input
    public event Action OnJumpStarted;
    public event Action OnJumpCanceled;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        InitializeActions();
    }
    
    void InitializeActions()
    {
        moveAction = playerInput.actions[Constants.InputActions.Move];
        jumpAction = playerInput.actions[Constants.InputActions.Jump];
    }

    void OnEnable()
    {
        SubscribeToInputActions();
        EnableActions();
    }

    void OnDisable()
    {
        UnsubscribeToInputActions();
        DisableActions();
    }

    void SubscribeToInputActions()
    {
        moveAction.started += OnMove;
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        jumpAction.started += OnJump;
        jumpAction.canceled += OnJump;
    }

    void UnsubscribeToInputActions()
    {
        moveAction.started -= OnMove;
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;

        jumpAction.started -= OnJump;
        jumpAction.canceled -= OnJump;
    }

    void EnableActions()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    void DisableActions()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OnMoveStarted?.Invoke();
                break;
            case InputActionPhase.Performed:
                MoveInput = context.ReadValue<Vector2>();
                OnMovePerformed?.Invoke(MoveInput);
                break;
            case InputActionPhase.Canceled:
                OnMoveCanceled?.Invoke();
                break;
        }
    }

    void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OnJumpStarted?.Invoke();
                break;
            case InputActionPhase.Canceled:
                OnJumpCanceled?.Invoke();
                break;
        }
    }
}