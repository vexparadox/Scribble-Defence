using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesScript : MonoBehaviour {
	public int StartLives; // holds the start amount of lives
	public int CurrentLives; // holds the current amount of lives
	public int CurrentLevel; // holds the current level number
	private string endMessage = "Placeholder"; // holds the end message
	public Text LivesLabel;
	public GUISkin endSkin;
	public string nextLevel;

	public bool gameover;
	private bool Win = false;

	private Rect windowRect = new Rect((Screen.width/2)-200,(Screen.height/2)-200, 400, 400);

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

	//on each frame check for game over(GUI VERSION)
	void OnGUI(){
		GUI.skin = endSkin;
		{
			if(gameover)
			{	
				//stop the enemies etc moving whilst the end screen is up
				Time.timeScale = 0;
				//load endscreen
				windowRect = GUILayout.Window(0, windowRect, endScreen, "");
			}
		}
	}

	//show the endscreen window
	void endScreen(int windowID){
		if (Win) {
			GUILayout.Label(endMessage);
			//go back to the menu
			if (GUILayout.Button ("Back to Level Select")) {
				Time.timeScale = 1;
				Application.LoadLevel("LevelSelect");
			}
			//have a next level button if it's not level 5
			if(CurrentLevel != 5){
				//continue to the next level
				if (GUILayout.Button ("Play the next level!")) {
					Time.timeScale = 1;
					Application.LoadLevel ("Level"+(CurrentLevel+1));
				}
			}
		} else {
			GUILayout.Label(endMessage);
			//go back to the menu
			if (GUILayout.Button ("Back to Level Select")) {
				Time.timeScale = 1;
				Application.LoadLevel("LevelSelect");
			}
			//retry the current level
			if (GUILayout.Button ("Retry the level")) {
				Time.timeScale = 1;
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
	}


	void GameOver(){
		if (Win) {
			//get the level number and make add it to the progression
			//only unlock the level if you're on the brink of your progression
			if(CurrentLevel >= PlayerPrefs.GetInt("LevelProgression")){
				Debug.Log("Level Unlocked");
				PlayerPrefs.SetInt ("LevelProgression", (CurrentLevel + 1));
			}
		}
	}
}
