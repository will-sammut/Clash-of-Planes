using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryCollision : MonoBehaviour
{
    Camera cam;
    public bool bounceable;
    // Start is called before the first frame update
    void Start()
    {
        bounceable = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
        Debug.Log($"{Screen.height} {screenPos.y}, {Screen.width} {screenPos.x}");
        if (bounceable)
        {
            if ((screenPos.y >= Screen.height) || (screenPos.y <= 0f))
            {
                GetComponent<MovementScript>().BounceVertical();
                bounceable = false;
            }
            if ((screenPos.x >= Screen.width) || (screenPos.x <= 0f))
            {
                GetComponent<MovementScript>().BounceHorizontal();
                bounceable = false;
            }
        }
        else
        {
            if ((screenPos.y < Screen.height) && (screenPos.y > 0f) && (screenPos.x < Screen.width) && (screenPos.x > 0f))
            {
                bounceable = true;
            }
        }
    }
}
