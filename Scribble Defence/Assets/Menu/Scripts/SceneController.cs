using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep; // stop screen from sleeping

		PlayerPrefs.DeleteKey ("LevelProgression");
		//check the level progression
		if (!PlayerPrefs.HasKey ("LevelProgression")) {
			PlayerPrefs.SetInt("LevelProgression", 1);
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

