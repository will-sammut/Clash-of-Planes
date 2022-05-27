using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLandingChecker : MonoBehaviour
{
    public Ray ray;

    private void OnMouseUp()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
