public class IxbalJumpState : State<IxbalController>
{
    public IxbalJumpState(IxbalController owner) : base(owner) { }

    protected internal override void Enter() { }

    protected internal override void Exit() { }

    protected internal override void UpdateLogic()
    {
        if (owner.IsGrounded)
        {
            if (owner.InputX is 0)
            {
                owner.StateMachine.ChangeState(owner.IdleState);
                return;
            }

            owner.StateMachine.ChangeState(owner.RunState);
            return;
        }
    }

    protected internal override void UpdatePhysics() { }
}