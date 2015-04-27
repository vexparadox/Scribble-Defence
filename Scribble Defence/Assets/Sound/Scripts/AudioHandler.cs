using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour {
	
	public AudioClip music1;
	public AudioClip sndFX1;
	public AudioSource audio;
	private bool playOnce;
	public int valueFX;
	// Use this for initialization
	void Start () {

		//if sound is turned on, play the music
		valueFX = PlayerPrefs.GetInt("SoundFX");
		if (PlayerPrefs.GetInt ("Sound") == 1) 
			playOnce = true;
		
		if (PlayerPrefs.GetInt ("SoundFX") == 1) {
			audio.PlayOneShot(sndFX1);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//should we play sound?
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			if(playOnce){
				audio.clip = music1;
				audio.Play();
			}
			playOnce = false;
		}else if(PlayerPrefs.GetInt ("Sound") == 0){
			audio.clip = music1;
			audio.Stop();
			playOnce = true;
		}
		
		
	}
}
