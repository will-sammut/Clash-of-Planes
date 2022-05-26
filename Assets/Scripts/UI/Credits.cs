using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    // Let's go back to the main menu
    // SM
    void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
