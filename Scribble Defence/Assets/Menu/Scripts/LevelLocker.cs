using UnityEngine;
using System.Collections;

public class LevelLocker : MonoBehaviour {
	public GameObject level2lock, level3lock, level4lock, level5lock;
	// Use this for initialization
	void Start () {
		int progression = PlayerPrefs.GetInt ("LevelProgression");
		Debug.Log (progression);
		//turns the padlocks on and off depending on how they're doing
		if (progression >= 2) {
			level2lock.GetComponent<SpriteRenderer>().enabled = false;
				}
		if (progression >= 3) {
			level3lock.GetComponent<SpriteRenderer> ().enabled = false;
				}
		if(progression >= 4){
			level4lock.GetComponent<SpriteRenderer>().enabled = false;
		}
		if (progression >= 5) {
			level5lock.GetComponent<SpriteRenderer>().enabled = false;
				}
	}
}
