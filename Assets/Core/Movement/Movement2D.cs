using UnityEngine;

public abstract class Movement2D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;

    Rigidbody2D rb;
    GroundCheck2D groundCheck;
    bool wasGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        CheckLanding();
        CheckFlip();
    }

    protected abstract void HandleMovement();

    protected virtual void CheckLanding()
    {
        if (!wasGrounded && groundCheck.IsGrounded)
        {
            CharacterEvents.Land(gameObject);
        }

        wasGrounded = groundCheck.IsGrounded;
    }

    protected void Move(float horizontalInput)
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        CharacterEvents.Move(gameObject, Mathf.Abs(rb.linearVelocity.x));
    }

    protected void Jump()
    {
        if (groundCheck.IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            CharacterEvents.Jump(gameObject);
        }
    }

    float Direction()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            return Mathf.Sign(rb.linearVelocity.x);
        }

        return 0f;
    }

    void CheckFlip()
    {
        float direction = Direction();
        if (direction != 0)
        {
            CharacterEvents.Flip(gameObject, direction);
        }
    }
}
