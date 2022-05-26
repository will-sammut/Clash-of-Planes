using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaneCollision : MonoBehaviour
{
    public UnityEvent onCollision;
    public GameObject particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ObjectIsVisible.collidable)
        {
            if (particles != null)
            {
                Instantiate(particles,transform.position,Quaternion.identity);
            }
            onCollision.Invoke();
            // End the game
            Destroy(transform.parent.gameObject);
            //Debug.Log($"{transform.parent.gameObject.name} has collided");
        }
    }
}