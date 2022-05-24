using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
        Debug.Log("collision");
        // End game script goes here
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        // Add one point to score
        Destroy(gameObject);
        Debug.Log("trigger");
    }
}
