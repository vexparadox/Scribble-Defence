using UnityEngine;
using System.Collections;

public class PlayClick : MonoBehaviour {
	public string LevelToLoad;
	// Use this for initialization
	void OnMouseDown(){
		Application.LoadLevel (LevelToLoad);
	
	}
}
