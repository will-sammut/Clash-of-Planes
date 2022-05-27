using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHelicopter : MonoBehaviour
{
    public SpriteRenderer helicopterBlade;
    private bool doOnce = false;

    private void Update()
    {
        if (!doOnce && gameObject.tag == "Helicopter")
        {
            doOnce = true;
            helicopterBlade.enabled = true;
            Debug.Log("is helicopter");
        }
    }
}
