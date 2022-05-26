using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateUiData : MonoBehaviour
{
	/* This script acts as a game manager. It contains the functions required 
	 * for amending the player's score, updating the time, pausing and loading
	 * a different scene. It was written by Stephen McGuinness and Angela Woodhouse on the 25/05/2022 */

	// Reference to the game management scriptable object
	[Header("Scriptable Objects")]
	public GameMangement gameManager;

	// UI elements 
	[Header("UI References")]
	public TextMeshProUGUI timerText;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI pauseText;
	public TextMeshProUGUI youLost;

	[Header("Extra")]
	public string scorePrefix = "Score: ";

	void Update()
	{
		timerText.text = gameManager.GameTimer();
		scoreText.text = scorePrefix + gameManager.score.ToString();
	}
}
