using UnityEngine;

public class Jump2D : MonoBehaviour
{
    [SerializeField] protected float jumpForce = 10f;
    [SerializeField] protected int maxJumps = 2;
    [SerializeField] protected float coyoteTime = 0.15f;
    [SerializeField] protected float jumpBufferTime = 0.1f;
    [SerializeField] protected float variableJumpMultiplier = 0.5f;

    Rigidbody2D rb;
    GroundCheck2D groundCheck;

    int jumpsUsed;
    float lastGroundedTime;
    float jumpPressedTime;
    bool jumpHeld;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck2D>();
    }

    void FixedUpdate()
    {
        UpdateGrounded();
        TryBufferedJump();
        ApplyVariableJumpHeight();
    }

    protected virtual void OnJumpPressed()
    {
        jumpPressedTime = Time.time;
        jumpHeld = true;
    }

    protected virtual void OnJumpReleased()
    {
        jumpHeld = false;
    }

    void UpdateGrounded()
    {
        if (groundCheck.IsGrounded)
        {
            lastGroundedTime = Time.time;
            jumpsUsed = 0;
        }
    }

    void TryBufferedJump()
    {
        bool bufferedJump = (Time.time - jumpPressedTime) <= jumpBufferTime;
        if (CanJump() && bufferedJump)
        {
            ExecuteJump();
            jumpPressedTime = -Mathf.Infinity;
        }
    }

    bool CanJump()
    {
        return groundCheck.IsGrounded || (Time.time - lastGroundedTime <= coyoteTime) || jumpsUsed < maxJumps;
    }

    void ExecuteJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpsUsed++;
        CharacterEvents.Jump(gameObject);
    }

    void ApplyVariableJumpHeight()
    {
        if (!jumpHeld && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * variableJumpMultiplier);
        }
    }
}
