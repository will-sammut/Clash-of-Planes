using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    public float offset;
    public float zSpawnPosition = 0;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Spawn();
    }

    public void Spawn()
    {
        int side = Random.Range(0, 3);
        float spawnX = 0;
        float spawnY = 0;

        switch (side)
        {
            case 0: // top
                spawnX = Random.Range(0, Screen.width);
                spawnY = Screen.height + offset;
                break;
            case 1: // right
                spawnX = Screen.width + offset;
                spawnY = Random.Range(0, Screen.height);
                break;
            case 2: // bottom
                spawnX = Random.Range(0, Screen.width);
                spawnY = 0 - offset;
                break;
            case 3: // left
                spawnX = 0 - offset;
                spawnY = Random.Range(0, Screen.height);
                break;
        }

        Vector3 spawnPoint = cam.ScreenToWorldPoint(new Vector3(spawnX, spawnY, cam.nearClipPlane));
        // KJ: cam.nearClipPlane spawned the planes out of touching distance but in viewing distance
        spawnPoint.z = zSpawnPosition;

        switch (side)
        {
            case 0: // top
                spawnPoint.y += offset;
                break;
            case 1: // right
                spawnPoint.x += offset;
                break;
            case 2: // bottom
                spawnPoint.y -= offset;
                break;
            case 3: // left
                spawnPoint.x -= offset;
                break;
        }

        GameObject newPlane = Instantiate(plane, spawnPoint, Quaternion.identity);
        Vector3 randomTarget = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), cam.nearClipPlane);
        newPlane.GetComponent<MovementScript>().spawnTarget = cam.ScreenToWorldPoint(randomTarget);
    }
}
