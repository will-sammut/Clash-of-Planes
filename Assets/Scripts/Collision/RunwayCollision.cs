using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayCollision : MonoBehaviour
{
    public List<string> allowedOnRunway = new List<string>();
    public void OnTriggerEnter2D(Collider2D other)
    {
        ILandable IPlane = other.gameObject.GetComponent<MovementScript>() as ILandable;
        //Debug.Log($"Is null?  {IPlane == null}");
        if (IPlane != null)
        {
            if(allowedOnRunway.Count == 0) return;
            foreach (string tag in allowedOnRunway)
            {
                //Debug.Log($"{tag} other is {other.gameObject.tag}");
                if (other.gameObject.tag == tag)
                {
                    break;
                }
                return;
            }
            if (IPlane.IsLanding())
            {
                Destroy(other.gameObject);
                //Debug.Log($"Landed {IPlane.IsLanding()}");
            }
        }
    }
}