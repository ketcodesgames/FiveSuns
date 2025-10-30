using UnityEngine;

public class IxbalAnimatorHandler : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        CharacterEvents.OnMove += HandleMove;
        CharacterEvents.OnJump += HandleJump;
        CharacterEvents.OnLand += HandleLand;
    }

    void OnDisable()
    {
        CharacterEvents.OnMove -= HandleMove;
        CharacterEvents.OnJump -= HandleJump;
        CharacterEvents.OnLand -= HandleLand;
    }

    void HandleMove(GameObject sender, float speed)
    {
        if (sender != gameObject) return;

        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    void HandleJump(GameObject sender)
    {
        if (sender != gameObject) return;

        animator.SetTrigger("Jump");
    }

    void HandleLand(GameObject sender)
    {
        if (sender != gameObject) return;

        animator.SetTrigger("Land");
    }
}
