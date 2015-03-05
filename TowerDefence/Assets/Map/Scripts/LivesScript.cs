using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesScript : MonoBehaviour {
	public int StartLives; // holds the start amount of lives
	public int CurrentLives; // holds the current amount of lives
	private string endMessage;
	public Text LivesLabel;
	public bool gameOver;
		
	// Use this for initialization
	void Start () {
		CurrentLives = StartLives;
		UpdateLivesUI();
	}
	
	// called from enemy movement when they reach the last waypoint!
	public void TakeALife(){
		CurrentLives--;
		UpdateLivesUI();
	}

	void Update(){
		if (gameOver) {
			Time.timeScale = 0;
			Debug.Log (endMessage);
		}
	}

	void UpdateLivesUI(){
		if (CurrentLives <= 0) {
			gameOver = true;
			endMessage = "You ran out of lives! :(";
				}
		LivesLabel.text = "Lives: " + CurrentLives;
	}

	//passed from EnemySpawnScript.JS
	public void levelWon(){
		gameOver = true;
		endMessage = "You did it yay!";
	}
}
