using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameMangement : MonoBehaviour
{
    /*This script acts as a game manager. It contains the functions required 
     * for amending the player's score, updating the time, pausing and loading
     * a different scene. It was written by Stephen McGuinness and Angela Woodhouse on the 25/05/2022 */


    //  u.i elements 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI youLost;

    //  score element used to update the score text
    public int score = 0;
    // timer element used to perpetually update
    private float timer;

    //  game states
    public enum GameStates
    {
        MainMenuScene,
        changeScene,
        pauseScene,
        resumeScene
    }

    //  current game state
    public GameStates currentGameState = GameStates.MainMenuScene; 

    // Update is called once per frame
    void Update()
    {
        GameTimer();
        //  if the user pressed the "space" button the following conditions occur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  checks the current scene against the pause scene
            if (currentGameState == GameStates.pauseScene)
            {
                currentGameState = GameStates.resumeScene;
            }
            else
            {
                currentGameState = GameStates.pauseScene;
            }

            
            // state machine     

            switch (currentGameState)
            {
                case(GameStates.MainMenuScene):
                    //Back to Main Menu (Buttons will be used here)
                    SceneManager.LoadScene("MovementScene");
                   // Time.timeScale = 0f;
                    break;
                case(GameStates.resumeScene):
                    Time.timeScale = 1f;
                    
                    Debug.Log("Resuming Scene");
                    break;
                case (GameStates.pauseScene):
                    Debug.Log("Paused scene");
                    Time.timeScale = 0f;
                    break;
            }
        }   
    }

    public void AmendScore()
    {
        score += 10;
        scoreText.text = "Score:" + score.ToString();
    }

    // method to notify the user on the time etc
    public void GameTimer()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int miliseconds = Mathf.FloorToInt((timer * 100f) % 100f);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
    
}
