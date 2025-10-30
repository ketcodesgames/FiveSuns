using System;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action<GameObject> OnFlipSprite;
    
    public static void FlipSprite(GameObject sender) => OnFlipSprite?.Invoke(sender);
}
