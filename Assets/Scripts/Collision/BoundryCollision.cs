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
            if ((screenPos.y > Screen.height) || (screenPos.y < 0f) || (screenPos.x > Screen.width) || (screenPos.x < 0f))
            {
                Debug.Log("Bounce");
                GetComponent<MovementScript>().Bounce();
                bounceable = false;
            }
        }
        else
        {
            if ((screenPos.y < (Screen.height - 1f)) && (screenPos.y > 1f) && (screenPos.x < (Screen.width - 1f)) && (screenPos.x > 1f))
            {
                Debug.Log("Now bounce");
                bounceable = true;
            }
        }
    }
}
