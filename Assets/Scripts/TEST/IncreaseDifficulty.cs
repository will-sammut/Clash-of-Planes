using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IncreaseDifficulty : MonoBehaviour
{
    public GameMangement gameManager;
    public UnityEvent onTimerFire;
    public List<DifficultyScale> difficultyScales;
    public float spawnFrequency;
    public float cooldownTimer;

    void Update()
    {
        // Check for higher scale
        foreach (DifficultyScale i in difficultyScales)
        {
            if (i.gameTime <= gameManager.timer)
            {
                spawnFrequency = i.frequency;
            }
        }

        // Increase Timer
        cooldownTimer += Time.deltaTime;

        // Trigger Invoke
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
