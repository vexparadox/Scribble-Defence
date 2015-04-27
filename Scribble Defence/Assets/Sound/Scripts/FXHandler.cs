using UnityEngine;
using System.Collections;

public class FXHandler : MonoBehaviour {
	
	public AudioSource audio;
	public AudioClip clip;
	// Use this for initialization
	void Start () {
		//only play if sndFx is turned on
		if (PlayerPrefs.GetInt ("SoundFX") == 1) {
			audio.PlayOneShot(clip);
		}
	}
}
