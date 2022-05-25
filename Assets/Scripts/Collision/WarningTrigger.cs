using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    public SpriteRenderer planeSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        planeSprite.color = Color.red;
        Debug.Log("Plane warning");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        planeSprite.color = Color.white;
    }
}
