using UnityEngine;

public class IxbalController : MonoBehaviour
{
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
}
