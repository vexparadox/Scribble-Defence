using UnityEngine;
using System.Collections;

public class BossAudioPlayer : MonoBehaviour {
	public AudioSource source;
	public AudioClip sound;
	// Use this for initialization
	void Start () {
		//only play the boss sound when sndFx is turned on
		if (PlayerPrefs.GetInt ("SoundFX") == 1) {
			source.Play();
		}
	}
}
