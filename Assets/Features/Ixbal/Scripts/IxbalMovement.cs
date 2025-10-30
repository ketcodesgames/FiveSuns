using UnityEngine;
using UnityEngine.InputSystem;

public class IxbalMovement : Movement2D
{
    Vector2 moveInput;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }

    void OnJump(InputValue value)
    {
        Jump();
    }

    protected override void HandleMovement()
    {
        Move(moveInput.x);
    }
}
