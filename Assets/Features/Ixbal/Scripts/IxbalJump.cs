using UnityEngine;

public class IxbalJump : Jump2D
{
    InputReader inputReader;

    protected override void Awake()
    {
        base.Awake();
        inputReader = GetComponent<InputReader>();
    }

    void OnEnable()
    {
        inputReader.OnJumpStarted += OnJumpPressed;
        inputReader.OnJumpCanceled += OnJumpReleased;
    }

    void OnDisable()
    {
        inputReader.OnJumpStarted -= OnJumpPressed;
        inputReader.OnJumpCanceled -= OnJumpReleased;
    }
}
