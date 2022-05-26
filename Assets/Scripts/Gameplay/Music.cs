using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script implements a playlist of background music
 * The songs are picked and played at random from an 
 * array of 15 songs.
 * Written by Angela Woodhouse 26/05/2022
*/
public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;
    public float volume = 0.5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        if (!audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, clip.Length));
        }
    }
    private void Update()
    {
        audioSource.volume = volume;

        if (!audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, clip.Length));
        }
    }

    public void ChangeSong(int songPicked)
    {
        audioSource.clip = clip[songPicked];
        audioSource.Play();
    }
}
