using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIsVisible : MonoBehaviour
{
    public static bool collidable = true;

    private void OnBecameVisible()
    {
        collidable = true;
        Debug.Log($"{gameObject.name} can collide");
    }

    private void OnBecameInvisible()
    {
        collidable = false;
        Debug.Log($"{gameObject.name} can not collide");
    }
}
