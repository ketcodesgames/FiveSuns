public class IxbalRunState : State<IxbalController>
{
    public IxbalRunState(IxbalController owner) : base(owner) { }

    protected internal override void Enter() { }

    protected internal override void Exit() { }

    protected internal override void UpdateLogic()
    {
        if (owner.IsGrounded is false) 
        {
            owner.StateMachine.ChangeState(owner.JumpState);
            return;
        }

        if (owner.InputX == 0)
        {
            owner.StateMachine.ChangeState(owner.IdleState);
            return;
        }
    }

    protected internal override void UpdatePhysics() { }
}