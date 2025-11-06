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
    }

    void OnDisable()
    {
        CharacterEvents.OnMove -= HandleMove;
        CharacterEvents.OnJump -= HandleJump;
    }

    void HandleMove(GameObject sender, float speed)
    {
        if (sender != gameObject) return;

        animator.SetFloat(IxbalConstants.AnimationStates.Run, Mathf.Abs(speed));
    }

    void HandleJump(GameObject sender)
    {
        if (sender != gameObject) return;

        animator.SetTrigger(IxbalConstants.AnimationStates.Jump);
    }
}
