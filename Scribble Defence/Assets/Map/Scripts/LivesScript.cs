using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesScript : MonoBehaviour {
	public int StartLives; // holds the start amount of lives
	public int CurrentLives; // holds the current amount of lives
	public int CurrentLevel; // holds the current level number
	private string endMessage; // holds the end message
	public Text LivesLabel;

	public bool gameover;
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

	void Update(){
		if (gameover) {
			Win = true;
			GameOver();
				}
	}

	void UpdateLivesUI(){
		if (CurrentLives <= 0) {
			endMessage = "You ran out of lives! :(";
			Win = false;
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
			//get the level number and make add it to the progression
			//only unlock the level if you're on the brink of your progression
			if(CurrentLevel >= PlayerPrefs.GetInt("LevelProgression")){
				Debug.Log("Level Unlocked");
				PlayerPrefs.SetInt ("LevelProgression", (CurrentLevel + 1));
			}
				} else {
			Debug.Log("Game Lost");
			Time.timeScale = 0;
				}
	}
}
