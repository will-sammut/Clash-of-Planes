using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Collision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Plane")
        {
            // End the game
            Destroy(gameObject);
            Debug.Log("Plane collision");
        }
        else if(other.gameObject.tag == "Runway")
        {
            ILandable IPlane = gameObject.GetComponent<MovementScript>() as ILandable;
            Debug.Log($"Is null?  {IPlane == null}");
            if (IPlane != null)
            {
                if (IPlane.IsLanding()) 
                {
                    Destroy(gameObject);
                    Debug.Log("Landed");
                }
            }
        }
    }
}