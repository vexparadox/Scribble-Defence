using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesScript : MonoBehaviour {
	public int StartLives; // holds the start amount of lives
	public int CurrentLives; // holds the current amount of lives
	public Text LivesLabel;
		
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

	void UpdateLivesUI(){
		if (CurrentLives <= 0) {
			Application.LoadLevel("MainMenu");
				}
		LivesLabel.text = "Lives: " + CurrentLives;
	}
}
