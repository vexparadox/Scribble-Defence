using UnityEngine;
using System.Collections;

public class SoundHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite;
	
	void Start(){
		//make sure it matches the current setting
		if (PlayerPrefs.GetInt("Sound") == 1) {
			On = true;
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			
		} else {
			On = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
		}
	}
	
	void OnMouseUp(){
		if (On) {
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
			PlayerPrefs.SetInt("Sound", 0); //save for next time
			On = false;
		} else { 
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			PlayerPrefs.SetInt("Sound", 1); //save for next time
			On = true;
		}
	}
}