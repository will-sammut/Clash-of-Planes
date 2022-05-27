using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLandingChecker : MonoBehaviour
{
    private void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log($"{}");
    }
}
