public class IxbalIdleState : State<IxbalController>
{
    public IxbalIdleState(IxbalController owner) : base(owner) { }

    protected internal override void Enter() { }

    protected internal override void Exit() { }

    protected internal override void UpdateLogic()
    {
        if (owner.IsGrounded is false) 
        {
            owner.StateMachine.ChangeState(owner.JumpState);
            return;
        }

        if (owner.InputX != 0)
        {
            owner.StateMachine.ChangeState(owner.RunState);
            return;
        }
    }

    protected internal override void UpdatePhysics() { }
}