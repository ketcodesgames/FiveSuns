using UnityEngine;
using UnityEngine.InputSystem;

public class IxbalMovement : Movement2D
{
    Vector2 moveInput;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    protected override void HandleMovement()
    {
        Move(moveInput.x);
    }

    internal float InputX => moveInput.x;
}
