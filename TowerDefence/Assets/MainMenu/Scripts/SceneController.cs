using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep; // stop screen from sleeping
	}
}
