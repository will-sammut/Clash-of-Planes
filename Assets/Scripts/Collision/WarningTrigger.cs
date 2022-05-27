using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarningTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource warningAudio;
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
            if (!warningAudio.isPlaying)
            {
                warningAudio.Play();
            }
        }
        else
        {
            warningSprite.enabled = false;
            warningAudio.Stop();
        }
    }
}
