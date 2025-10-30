using UnityEngine;

public class GroundCheck2D : MonoBehaviour
{
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    public bool IsGrounded { get; private set; }

    void FixedUpdate()
    {
        if (groundCheckPoint == null)
        {
            Debug.LogWarning("GroundCheckPoint not assigned", this);
            return;
        }

        IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
}
