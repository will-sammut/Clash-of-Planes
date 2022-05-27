using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    public SpriteRenderer warningSprite;
    private bool planeInRange;

    [SerializeField] int warningSpeed = 150;

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
            warningSprite.transform.Rotate(new Vector3(0, 0, warningSpeed * Time.deltaTime));
            warningSprite.enabled = true;
        }
        else
        {
            warningSprite.enabled = false;
        }
    }
}
