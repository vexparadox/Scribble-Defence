using UnityEngine;
using System.Collections;

public class SettingsScript : MonoBehaviour {
	private float timeOnPause; //records timescale on pause
	private bool pauseMenu = false; // if it's paused or not
	public GUISkin pauseSkin; // the GUI skin for the pause menu
	private Rect windowRect = new Rect((Screen.width/2)-200,(Screen.height/2)-200, 400, 400); //pause menu

	void OnMouseUp(){
		Debug.Log ("Settings");

		//if opening the pauseMenu, set to 0
		//else return to previous value
		if (!pauseMenu) {
			timeOnPause = Time.timeScale;
			Time.timeScale = 0;
		} else {
			//do nothing, they must press resume to continue the game
		}

		//flip the boolean
		pauseMenu = !pauseMenu;
	}

	// Update is called once per frame
	void OnGUI () {
		GUI.skin = pauseSkin;
		if (pauseMenu) {
			windowRect = GUILayout.Window(0, windowRect, pauseScreen, "");
		}
	}

	void pauseScreen(int windowID){
		GUILayout.Label("Game paused!");
		//go back to the menu
		if (GUILayout.Button ("Resume Game")) {
			//resume the game
			pauseMenu = false;
			Time.timeScale = timeOnPause;
		}
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
