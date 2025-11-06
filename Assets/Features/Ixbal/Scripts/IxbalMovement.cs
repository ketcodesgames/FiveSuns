using UnityEngine;

public class IxbalMovement : Movement2D
{
    InputReader inputReader;

    protected override void Awake()
    {
        base.Awake();
        inputReader = GetComponent<InputReader>();
    }

    void OnEnable()
    {
        inputReader.OnMovePerformed += HandleMoveInputStart;
        inputReader.OnMoveCanceled += HandleMoveInputStop;
    }

    void OnDisable()
    {
        inputReader.OnMovePerformed -= HandleMoveInputStart;
        inputReader.OnMoveCanceled -= HandleMoveInputStop;
    }

    internal float InputX => inputReader.MoveInput.x;
}
