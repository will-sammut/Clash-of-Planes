using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Play() {
        // Get next scene in build index. 
        Debug.Log("Play Button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit() {
        //Quit game.
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }

    public void Settings() {
        Debug.Log("Settings Button Pressed");
        // Open settings menu.
        // SceneManager.LoadScene("Settings", LoadSceneMode.Additive());
    }
}
