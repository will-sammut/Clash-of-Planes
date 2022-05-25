using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public float offset;
    public float zSpawnPosition = 0;

    [Header("Plane Settings")]
    public GameObject plane;
    [SerializeField] private float targetZoneOffset = 20f;

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
        float x = Random.Range(targetZoneOffset, Screen.width - targetZoneOffset);
        float y = Random.Range(targetZoneOffset, Screen.height - targetZoneOffset);
        Vector2 randomTarget = cam.ScreenToWorldPoint(new Vector3(x, y, cam.nearClipPlane));
        newPlane.GetComponent<MovementScript>().ChangeDirection(randomTarget);
    }

    private void OnDrawGizmos()
    {
        // TODO: Display where planes can be directed to and the targetZoneOffset
        //Gizmos.color = Color.white;
        //Vector2 bottom = Camera.main.ScreenToWorldPoint(new Vector3(targetZoneOffset, targetZoneOffset, Camera.main.nearClipPlane));
        //Vector2 top = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - targetZoneOffset, Screen.height - targetZoneOffset, Camera.main.nearClipPlane));
        //Vector2 bt = new Vector2(bottom.x, top.y);
        //Vector2 tb = new Vector2(top.x, bottom.y);
        //Gizmos.DrawLine(bottom, tb);
        //Gizmos.DrawLine(bt, top);
        //Gizmos.DrawLine(bt, bottom);
        //Gizmos.DrawLine(top, tb);
    }
}
