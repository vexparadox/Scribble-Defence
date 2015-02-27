using UnityEngine;
using System.Collections;

public class PlayClick : MonoBehaviour {
	public string LevelToLoad;
	// Use this for initialization
	void OnMouseUp(){
		Application.LoadLevel (LevelToLoad);
	}
}
