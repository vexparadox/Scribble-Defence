using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesScript : MonoBehaviour {
	public int StartLives; // holds the start amount of lives
	public int CurrentLives; // holds the current amount of lives
	private string endMessage;
	public Text LivesLabel;

	private bool Win = false;

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

	void UpdateLivesUI(){
		if (CurrentLives <= 0) {
			endMessage = "You ran out of lives! :(";
			GameOver();
				}
		LivesLabel.text = CurrentLives.ToString();
	}

	//passed from EnemySpawnScript.JS
	public void levelWon(){
		Win = true;
		GameOver();
	}

	void GameOver(){
		if (Win) {
			int progression = PlayerPrefs.GetInt ("LevelProgression");
			PlayerPrefs.SetInt ("LevelProgression", progression + 1);
				}
	}
}
