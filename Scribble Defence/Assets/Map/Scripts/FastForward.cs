using UnityEngine;
using System.Collections;

public class FastForward : MonoBehaviour {
	private bool On = false;
	public Sprite offSprite, onSprite;

	void OnMouseDown(){
		On = !On;
		if (On) {
			Time.timeScale = 1;
			gameObject.GetComponent<SpriteRenderer>().sprite = offSprite; //swap the sprite

		} else {
			Time.timeScale = 2.5f;
			gameObject.GetComponent<SpriteRenderer>().sprite = onSprite; //swap the sprite

				}

	}

}
