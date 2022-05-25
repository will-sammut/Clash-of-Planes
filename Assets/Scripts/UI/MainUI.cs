using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] public TMP_Text  planeName;
    [SerializeField] public TMP_Text  planeSpeed;
    [SerializeField] public TMP_Text  planeDestination;
    
    public PlaneObject plane;

    public void GetPlaneData(PlaneObject plane) {
        this.plane = plane;
    } 

    public void DisplayPlaneDetails() {
        // Get details of currently selected aircraft.
        // Display in UI.

        planeName.text = plane.name;
        planeSpeed.text = plane.speed.ToString();
        planeDestination.text = plane.destination;
    }

    public void PauseGame() {
        // Pause game time.
        // Display pause UI (Quit, Settings).
    }
}
