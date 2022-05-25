using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateUiData : MonoBehaviour
{
    /*This script acts as a game manager. It contains the functions required 
  * for amending the player's score, updating the time, pausing and loading
  * a different scene. It was written by Stephen McGuinness and Angela Woodhouse on the 25/05/2022 */

    //reference to the game management scriptable object
    public GameMangement gameManager;
    //  u.i elements 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI youLost;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = gameManager.GameTimer();
        scoreText.text = gameManager.score.ToString();
    }
    
    
}
