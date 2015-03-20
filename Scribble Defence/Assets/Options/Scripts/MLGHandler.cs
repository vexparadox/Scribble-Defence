using UnityEngine;
using System.Collections;

public class MLGHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite;
	
	void Start(){
		if (PlayerPrefs.GetInt("MLG") == 1) {
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
			PlayerPrefs.SetInt("MLG", 0);
			On = false;
		} else { 
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
			PlayerPrefs.SetInt("MLG", 1);
			On = true;
		}
	}
}
