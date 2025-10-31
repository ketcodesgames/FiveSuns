using UnityEngine;

public abstract class Movement2D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
        CheckFlip();
    }

    protected abstract void HandleMovement();

    protected void Move(float horizontalInput)
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        CharacterEvents.Move(gameObject, Mathf.Abs(rb.linearVelocity.x));
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
