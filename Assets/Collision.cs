using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
   

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
        Debug.Log(other);
      // End game script goes here
    }
}

