using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHelicopter : MonoBehaviour
{
    public SpriteRenderer helicopterBlade;

    // Start is called before the first frame update
    private void Start()
    {
        if(gameObject.tag == "Helicopter")
        {
            helicopterBlade.enabled = true;
            Debug.Log("is helicopter");
        }
    }

    private void Update()
    {
        
    }
}
