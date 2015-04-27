using UnityEngine;
using System.Collections;

public class SoundHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite;
	public AudioClip clip1;
	public AudioSource audio;
	
	
	void Start(){
		
		//PlayerPrefs.SetInt("Sound",1);
		//make sure it matches the current setting
		if (PlayerPrefs.GetInt("Sound") == 1) {
			On = true;
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			audio.clip = clip1;
			audio.Play();
		} else {
			On = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
			audio.clip = clip1;
			audio.Stop();
		}
	}
	
	void OnMouseUp(){
		if (On) {
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
			PlayerPrefs.SetInt("Sound", 0); //save for next time
			On = false;
			audio.clip = clip1;
			audio.Stop();
		} else { 
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			PlayerPrefs.SetInt("Sound", 1); //save for next time
			On = true;
			audio.clip = clip1;
			audio.Play();
		}
	}
}