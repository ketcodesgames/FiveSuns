using UnityEngine;
using UnityEngine.InputSystem;

public class IxbalJump : Jump2D
{
    InputAction jumpAction;

    protected override void Awake()
    {
        base.Awake();

        var PlayerInput = GetComponent<PlayerInput>();
        
        jumpAction = PlayerInput.actions["Jump"];
        jumpAction.started += OnJump;
        jumpAction.canceled += OnJump;
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) OnJumpPressed();
        if (context.canceled) OnJumpReleased();
    }
}
