using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "Game Management", menuName = "Scriptable Objects/Game Management")]
public class GameMangement : ScriptableObject
{
    /*This script acts as a game manager. It contains the functions required 
     * for amending the player's score, updating the time, pausing and loading
     * a different scene. It was written by Stephen McGuinness and Angela Woodhouse on the 25/05/2022 */

    public PlaneObject planeSelected;
 
    //  score element used to update the score text
    public int score = 0;

    // timer element used to perpetually update
    public float timer;

    // Audio Clip
    [SerializeField] AudioClip audio = null;
    public AudioClip Audio { get { return audio; } }


    // bool to ensure either pause or resume the scene
    public bool isPaused { get; private set; } = false;

    //  game states
    // [System.Serializable] public enum SceneState
    // {
    //     MainMenu = 0,
    //     PlayScene = 1
    // }

    //  current game state
    

    // Update is called once per frame
    public void Pause(bool isPause)
    {
        //Sets the state of the scene
        isPaused = isPause;
        Time.timeScale = isPause ? 0f : 1f;
    }

    public void PauseToggle() => Pause(!isPaused);

    // amends the score 
    public void AmendScore(int score)
    {
        this.score += score;
    }

    public void OnEnable()
    {
        Pause(false);
        ResetData();
    }
    // resets both the time and score to zero
    public void ResetData()
    {
        score = 0;
        timer = 0;
    }
    // scene manager 
    public void SceneChanger(string scene)
    {
        SceneManager.LoadScene(scene);       
    }

    // method to notify the user on the time etc
    public string GameTimer()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int miliseconds = Mathf.FloorToInt((timer * 100f) % 100f);
        return minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
    
}
