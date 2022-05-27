using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryCollision : MonoBehaviour
{
    private Camera cam;
    private bool onScreen;
    [SerializeField] private GameObject warningObject;
    private GameObject warning;
    private bool warningOn;
    [SerializeField] private float warningOffset;
    [SerializeField] private float boundryWarningOffset;

    // Start is called before the first frame update
    void Start()
    {
        onScreen = false;
        cam = Camera.main;
        warningOn = false;
    }

    private void OnDestroy()
    {
        if (warning != null)
        {
            Destroy(warning);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
        if (onScreen)
        {
            if ((screenPos.y >= Screen.height) || (screenPos.y <= 0f))
            {
                GetComponent<MovementScript>().BounceVertical();
                onScreen = false;
            }
            if ((screenPos.x >= Screen.width) || (screenPos.x <= 0f))
            {
                GetComponent<MovementScript>().BounceHorizontal();
                onScreen = false;
            }
        }
        else
        {
            // becomes on screen
            if ((screenPos.y < Screen.height) && (screenPos.y > 0f) && (screenPos.x < Screen.width) && (screenPos.x > 0f))
            {
                onScreen = true;
                Destroy(warning);
                warningOn = false;
            }

            if (!warningOn)
            {
                if (warning == null)
                {
                    AddWarning(screenPos);
                }
            }
            else
            {
                UpdateWarning(screenPos);
            }
        }
    }

    private void AddWarning(Vector2 planePos)
    {
        // off to left
        if (planePos.x < 0f - boundryWarningOffset)
        {
            warning = Instantiate(warningObject, Vector2ScreenToWorldPoint(new Vector2(warningOffset, planePos.y), 0), Quaternion.identity);
            warningOn = true;
        }
        // off to right
        if (planePos.x > Screen.width + boundryWarningOffset)
        {
            warning = Instantiate(warningObject, Vector2ScreenToWorldPoint(new Vector2(Screen.width - warningOffset, planePos.y), 0), Quaternion.identity);
            warningOn = true;
        }
        // off to bottom
        if (planePos.y < 0f - boundryWarningOffset)
        {
            warning = Instantiate(warningObject, Vector2ScreenToWorldPoint(new Vector2(planePos.x, warningOffset), 0), Quaternion.identity);
            warningOn = true;
        }
        // off to top
        if (planePos.y > Screen.height + boundryWarningOffset)
        {
            warning = Instantiate(warningObject, Vector2ScreenToWorldPoint(new Vector2(planePos.x, Screen.height - warningOffset), 0), Quaternion.identity);
            warningOn = true;
        }
    }

    private void UpdateWarning(Vector2 planePos)
    {
        if (planePos.x < 0f - boundryWarningOffset)
        {
            warning.GetComponent<Transform>().position = Vector2ScreenToWorldPoint(new Vector2(warningOffset, planePos.y), 0);
        }
        // off to right
        if (planePos.x > Screen.width + boundryWarningOffset)
        {
            warning.GetComponent<Transform>().position = Vector2ScreenToWorldPoint(new Vector2(Screen.width - warningOffset, planePos.y), 0);
        }
        // off to bottom
        if (planePos.y < 0f - boundryWarningOffset)
        {
            warning.GetComponent<Transform>().position = Vector2ScreenToWorldPoint(new Vector2(planePos.x, warningOffset), 0);
        }
        // off to top
        if (planePos.y > Screen.height + boundryWarningOffset)
        {
            warning.GetComponent<Transform>().position = Vector2ScreenToWorldPoint(new Vector2(planePos.x, Screen.height - warningOffset), 0);
        }
    }

    private Vector3 Vector2ScreenToWorldPoint(Vector2 point, float z)
    {
        return new Vector3(cam.ScreenToWorldPoint(point).x, cam.ScreenToWorldPoint(point).y, z);
    }
}
