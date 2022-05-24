using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void Update() 
    {
        Vector3 movement = transform.position;

        movement.y += -0.01f;

        transform.position = movement;
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Plane")
        {
            // End the game
            Destroy(gameObject);
            Debug.Log("Plane collision");
        }
        else if(other.gameObject.tag == "Runway")
        {
            // Add one point to score
            Destroy(gameObject);
            Debug.Log("Plane landed");
        }
    }
}
