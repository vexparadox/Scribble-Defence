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
	
	// Update is called once per frame
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
	
	void OnGUI(){
			//GUILayout.Window(Rect(Screen.width/2,Screen.height/2, 60,40), "The End!");
			//GUILayout.Label(Rect(Screen.width/2,Screen.height/2-15,1,1), ""+endMessage);
			/* GUI broken, I think this might be the JS version
			if(GUILayout.Button(new Rect(Screen.width/2, Screen.height/2, 50, 15), "Back to the menu"));
			{
				Application.LoadLevel("MainMenU");
			}
			if(GUILayout.Button(new Rect(Screen.width/2+15, Screen.height/2+15,50,15), "Restart"));
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
			*/
		}

}
