using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        ILandable IPlane = other.gameObject.GetComponent<MovementScript>() as ILandable;
        //Debug.Log($"Is null?  {IPlane == null}");
        if (IPlane != null)
        {
            if (IPlane.IsLanding())
            {
                Destroy(other.gameObject);
                Debug.Log($"Landed {IPlane.IsLanding()}");
            }
        }
    }
}