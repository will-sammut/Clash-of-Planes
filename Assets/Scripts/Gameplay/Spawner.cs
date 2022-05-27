using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public float offset;
    public float zSpawnPosition = 0;
    public UnityEvent onSpawn;

    [Header("Plane Settings")]
    public GameObject plane;
    [SerializeField] private float targetZoneOffset = 20f;
    [SerializeField] private List<PlaneSpawnWeights> planeProfiles = new List<PlaneSpawnWeights>();

    private Camera cam;
    
    // For GIZMO
    private Vector2 bottom = Vector2.zero;
    private Vector2 top = Vector2.zero;

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

        // GIZMO
        bottom = Camera.main.ScreenToWorldPoint(new Vector3(targetZoneOffset, targetZoneOffset, Camera.main.nearClipPlane));
        top = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - targetZoneOffset, Screen.height - targetZoneOffset, Camera.main.nearClipPlane));
        // END GIZMO

        GameObject newPlane = Instantiate(plane, spawnPoint, Quaternion.identity);
        float x = Random.Range(targetZoneOffset, Screen.width - targetZoneOffset);
        float y = Random.Range(targetZoneOffset, Screen.height - targetZoneOffset);
        Vector2 randomTarget = cam.ScreenToWorldPoint(new Vector3(x, y, cam.nearClipPlane));
        MovementScript ms = newPlane.GetComponent<MovementScript>();
        ms.ChangeDirection(randomTarget);
        onSpawn.Invoke();

        // "Random" plane profile
        if (planeProfiles != null && planeProfiles.Count > 0)
        {
            float weight = 0;
            foreach (PlaneSpawnWeights i in planeProfiles)
            {
                weight += i.weight;
            }
            float random = Random.Range(0f, weight);
            foreach (PlaneSpawnWeights i in planeProfiles)
            {
                random -= i.weight;
                if (random <= 0)
                {
                    if (i.plane != null)
                    {
                        ms.SetPlaneObject(i.plane);
                    }
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // TODO: Display where planes can be directed to and the targetZoneOffset
        Gizmos.color = Color.white;
        Vector2 bt = new Vector2(bottom.x, top.y);
        Vector2 tb = new Vector2(top.x, bottom.y);
        Gizmos.DrawLine(bottom, tb);
        Gizmos.DrawLine(bt, top);
        Gizmos.DrawLine(bt, bottom);
        Gizmos.DrawLine(top, tb);
    }
}

[System.Serializable]
public class PlaneSpawnWeights
{
    public PlaneObject plane;
    [Range(0f, 1f)]
    public float weight = 1;
}