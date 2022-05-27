using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    public GameMangement gameMangement;
    public GameObject UI;
    public CanvasGroup canvasGroup;

    public float fadeStepTime = 0.1f;
    public float finalAlphaValue = 0.4f;

    private void Start()
    {
        if (gameMangement != null)
        {
            gameMangement.onGameEnd.AddListener(Trigger);
            UI.SetActive(gameMangement.gameEnded);
        }

        if (canvasGroup != null)
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }
    }

    private void Trigger()
    {
        UI.SetActive(true);
        canvasGroup.interactable = true;
        StartCoroutine(FadeIn(fadeStepTime, finalAlphaValue));
    }

    private IEnumerator FadeIn(float timer, float endValue)
    {
        for (float alpha = 0; alpha < endValue; alpha += timer)
        {
            canvasGroup.alpha = alpha;
            yield return new WaitForSecondsRealtime(timer);
        }
        gameMangement.Pause(true);
    }
}
