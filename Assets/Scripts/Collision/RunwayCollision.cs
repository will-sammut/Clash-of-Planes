using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayCollision : MonoBehaviour
{
    public List<string> allowedOnRunway = new List<string>();
    public void OnTriggerStay2D(Collider2D other)
    {
        Vector2 centerPos = transform.position;
        Vector2 otherPos = other.transform.position;

        bool isRight = centerPos.x > otherPos.x;
        bool isAbove = centerPos.y > otherPos.y;

        ILandable IPlane = other.gameObject.GetComponent<MovementScript>() as ILandable;
        //Debug.Log($"Is null?  {IPlane == null}");
        if (IPlane != null)
        {
            bool foundTag = false;
            if(allowedOnRunway.Count == 0) return;
            foreach (string tag in allowedOnRunway)
            {
                //Debug.Log($"{tag} other is {other.gameObject.tag}");
                if (other.gameObject.tag == tag)
                {
                    foundTag = true;
                    break;
                }
            }
            if (!foundTag) return;
            if (IPlane.IsLanding())
            {
                other.gameObject.GetComponent<Landing>().LandPlane();
                //Debug.Log($"Landed {IPlane.IsLanding()}");
            }
        }
    }
}