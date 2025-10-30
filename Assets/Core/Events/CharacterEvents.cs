using System;
using UnityEngine;

public static class CharacterEvents
{
    public static event Action<GameObject, float> OnMove;
    public static event Action<GameObject> OnJump;
    public static event Action<GameObject> OnLand;
    public static event Action<GameObject, float> OnFlip;
    
    public static void Move(GameObject sender, float speed) => OnMove?.Invoke(sender, speed);
    public static void Jump(GameObject sender) => OnJump?.Invoke(sender);
    public static void Land(GameObject sender) => OnLand?.Invoke(sender);
    public static void Flip(GameObject sender, float direction) => OnFlip?.Invoke(sender, direction);
}
