using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep; // stop screen from sleeping

		//check the level progression exisits, else set it to 1
		if (PlayerPrefs.GetInt("LevelProgression") < 1) {
			PlayerPrefs.SetInt("LevelProgression", 1);
		}

		if (PlayerPrefs.GetInt ("DevMode") == 1) {
			PlayerPrefs.SetInt("LevelProgression", 5);
				}
	
		//check vsync options
		int VSyncPrefs = PlayerPrefs.GetInt ("VSync"); //get player preferences
		if (VSyncPrefs == 0 || !PlayerPrefs.HasKey("VSync")) {
			QualitySettings.vSyncCount = 0; // turn of VSync
		} else {
			QualitySettings.vSyncCount = 1; 
		}
	}
}

