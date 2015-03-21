using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
	public int LevelAttached;
	public string LevelToLoad;
	private int progression;

	void Start(){
		progression = PlayerPrefs.GetInt ("LevelProgression");
		}
	void OnMouseDown(){
		//if they've unlocked the level, load it
		if (progression >= LevelAttached) {
			Application.LoadLevel(LevelToLoad);
				}
	}
}
