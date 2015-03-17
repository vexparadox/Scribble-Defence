using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep; // stop screen from sleeping

		int VSyncPrefs = PlayerPrefs.GetInt ("VSync"); //get player preferences
		if (VSyncPrefs == 0 || VSyncPrefs == null) {
			QualitySettings.vSyncCount = 0; // turn of VSync
		} else {
			QualitySettings.vSyncCount = 1; 
		}
	}
}

