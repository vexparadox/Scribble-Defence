using UnityEngine;
using System.Collections;

public class VSyncHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite;

	void Start(){
		//make sure it matches the current setting
		if (QualitySettings.vSyncCount == 1) {
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
		QualitySettings.vSyncCount = 0; //turn off vSync
		PlayerPrefs.SetInt("VSync", 0); //save for next time
		On = false;
			} else { 
		gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
		QualitySettings.vSyncCount = 1; //turn on vSync
		PlayerPrefs.SetInt("VSync", 1); //save for next time
		On = true;
			}
	}
}
