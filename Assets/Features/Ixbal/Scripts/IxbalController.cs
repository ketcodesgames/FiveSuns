using UnityEngine;

public class IxbalController : MonoBehaviour
{
    IxbalMovement ixbalMovement;
    IxbalJump ixbalJump;
    Rigidbody2D rb;
    GroundCheck2D groundCheck;

    StateMachine<IxbalController> stateMachine;
    IxbalIdleState idleState;
    IxbalRunState runState;
    IxbalJumpState jumpState;

    void Awake()
    {
        ixbalMovement = GetComponent<IxbalMovement>();
        ixbalJump = GetComponent<IxbalJump>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck2D>();

        stateMachine = new StateMachine<IxbalController>();

        idleState = new IxbalIdleState(this);
        runState = new IxbalRunState(this);
        jumpState = new IxbalJumpState(this);
    }

    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.CurrentState.UpdateLogic();
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.UpdatePhysics();
    }
    
    void OnEnable()
    {
        CharacterEvents.OnFlip += HandleFlip;
    }

    void OnDisable()
    {
        CharacterEvents.OnFlip -= HandleFlip;
    }

    void HandleFlip(GameObject sender, float direction)
    {
        if (sender != gameObject) return;

        transform.localScale = new Vector2(direction, 1f);
    }

    public float InputX => ixbalMovement.InputX;
    public bool IsGrounded => groundCheck.IsGrounded;
    public float VelocityY => rb.linearVelocity.y;

    internal StateMachine<IxbalController> StateMachine => stateMachine;
    internal IxbalIdleState IdleState => idleState;
    internal IxbalRunState RunState => runState;
    internal IxbalJumpState JumpState => jumpState;
}
