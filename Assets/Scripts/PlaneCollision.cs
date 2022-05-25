using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // End the game
        Destroy(transform.parent.gameObject);
        Debug.Log($"{transform.parent.gameObject.name} has collided");
    }
}
