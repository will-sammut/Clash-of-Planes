using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public float zoneSize = 1000;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
        float posUpY = Screen.height + zoneSize;
        float posDownY = 0f - zoneSize;
        float posLeftX = Screen.width + zoneSize;
        float posRightX = 0f - zoneSize;
        if ((screenPos.y > posUpY) || (screenPos.y < posDownY) || (screenPos.x > posLeftX) || (screenPos.x < posRightX))
        {
            Destroy(gameObject);
        }
    }
}
