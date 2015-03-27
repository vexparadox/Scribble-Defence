using UnityEngine;
using System.Collections;

public class DevModeHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite;
	
	void Start(){
		//make sure it matches the current setting
		if (PlayerPrefs.GetInt("DevMode") == 1) {
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
			PlayerPrefs.SetInt("DevMode", 0); //save for next time
			PlayerPrefs.SetInt("LevelProgression", 1);
			On = false;
		} else { 
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			PlayerPrefs.SetInt("DevMode", 1); //save for next time
			PlayerPrefs.SetInt("LevelProgression", 5);
			On = true;
		}
	}
}