using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// KJ: Hey if you came here to fix the out of bounds destruction bug...
//     it's not a bug it's because the editor camera counts towards visibility.
public class ObjectIsVisible : MonoBehaviour
{
    public bool collidable = false;
    public float invincibilityTime = 0.5f;

    private void OnBecameVisible()
    {
        Invoke(nameof(MakeCollidable), invincibilityTime);
    }

    private void OnBecameInvisible()
    {
        collidable = false;
    }

    private void MakeCollidable() => collidable = true;
}
