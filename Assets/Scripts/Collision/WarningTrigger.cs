using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    public SpriteRenderer warningSprite;
    private bool planeInRange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        planeInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        planeInRange = false;
    }

    private void Update()
    {
        if(planeInRange)
        {
            warningSprite.enabled = true;
        }
        else
        {
            warningSprite.enabled = false;
        }
    }
}
