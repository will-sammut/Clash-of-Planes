using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    private SpriteRenderer arrowSprite;

    private void Start()
    {
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");

        foreach (GameObject arrow in arrows)
        {
            if(arrow.GetComponent<ArrowTags>().SameTags(gameObject.tag))
            {
                arrowSprite = arrow.GetComponent<SpriteRenderer>();
                arrowSprite.enabled = false;
            }
        }
    }

    private void OnMouseDrag()
    {
        arrowSprite.enabled = true;
    }

    private void OnMouseUp()
    {
        arrowSprite.enabled = false;
    }
}
