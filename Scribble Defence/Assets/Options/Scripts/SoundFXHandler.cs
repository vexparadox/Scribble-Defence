using UnityEngine;
using System.Collections;

public class SoundFXHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite;
	public AudioClip clip1;
	public AudioSource audio;
	public int valueFX;
	
	void Start(){
		//make sure it matches the current setting
		valueFX = PlayerPrefs.GetInt("SoundFX");
		if (PlayerPrefs.GetInt("SoundFX") == 1) {
			On = true;
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			audio.PlayOneShot(clip1);
			
		} else {
			On = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
			
		}
		
	}
	
	void OnMouseUp(){
		if (On) {
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
			PlayerPrefs.SetInt("SoundFX", 0); //save for next time
			On = false;
			valueFX = PlayerPrefs.GetInt("SoundFX");
			
		} else { 
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			PlayerPrefs.SetInt("SoundFX", 1); //save for next time
			On = true;
			valueFX = PlayerPrefs.GetInt("SoundFX");
			audio.PlayOneShot(clip1);
		}
	}
}