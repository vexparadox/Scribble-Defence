using UnityEngine;
using System.Collections;

public class VSyncHandler : MonoBehaviour {
	private bool On = false;
	public Sprite offSprite, onSprite;

	void OnMouseUp(){
		if (On) {
		gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite
		QualitySettings.vSyncCount = 0; //turn off vSync
		On = false;
			} else { 
		gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap sprite
		QualitySettings.vSyncCount = 1; //turn on vSync
		On = true;
			}
	}
}
