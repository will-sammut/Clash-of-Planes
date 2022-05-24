using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Collision : MonoBehaviour
{
<<<<<<< Updated upstream
    void Update() 
    {
        Vector3 movement = transform.position;

        movement.y += -0.01f;

        transform.position = movement;
    }
=======
>>>>>>> Stashed changes
    
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
