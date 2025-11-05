public abstract class State<T>
{
    protected T owner;

    protected State(T owner)
    {
        this.owner = owner;
    }

    protected internal abstract void Enter();
    protected internal abstract void Exit();
    protected internal abstract void UpdateLogic();
    protected internal abstract void UpdatePhysics();
}