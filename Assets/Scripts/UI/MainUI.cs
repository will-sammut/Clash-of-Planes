// W

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TMP_Text  planeName;
    [SerializeField] private TMP_Text  planeSpeed;
    [SerializeField] private TMP_Text  planeDestination;
    
    public GameMangement gameManager;

    public PlaneObject plane;

    public void GetPlaneData(PlaneObject plane) {
        this.plane = plane;

        // Assign plane object attributes to UI text content.
        planeName.text = plane.name;
        planeSpeed.text = plane.speed.ToString();
        planeDestination.text = plane.destination;

    } 

    public void Update() {
        if (gameManager.planeSelected != null){
            GetPlaneData(gameManager.planeSelected);
        }
    }
}
