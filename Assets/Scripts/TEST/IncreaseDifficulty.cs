using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IncreaseDifficulty : MonoBehaviour
{
    public GameMangement gameManager;
    public Spawner spawner;

    public UnityEvent onTimerFire;

    public List<DifficultyScale> difficultyScales;
    public float spawnFrequency;
    public float cooldownTimer;

    GameObject numberOfPlanes;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DifficultyScale i in difficultyScales)
        {
            if (i.gameTime <= gameManager.timer)
            {
                spawnFrequency = i.frequency;
            }
        }
        
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= spawnFrequency)
        {
            onTimerFire.Invoke();
            cooldownTimer = 0;
        }
    }
}

[System.Serializable]
public struct DifficultyScale
{
    public float gameTime;
    public float frequency;
}
