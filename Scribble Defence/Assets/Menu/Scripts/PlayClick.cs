using UnityEngine;
using System.Collections;

public class PlayClick : MonoBehaviour {
	public string LevelToLoad;
	// Use this for initialization
	void OnMouseUp(){
		//make sure all speeds are releveled on level load
		Time.timeScale = 1;
		Application.LoadLevel (LevelToLoad);
	}
}
