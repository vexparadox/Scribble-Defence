using UnityEngine;
using System.Collections;

public class HardModeHandler : MonoBehaviour {
	private bool On;
	public Sprite offSprite, onSprite, locked;
	
	void Start(){

		//if they've got to level 5, then activate hard mode
		if (PlayerPrefs.GetInt ("LevelProgression") < 5) {
			setLocked();
			PlayerPrefs.SetInt("HardMode", 0);
		} else if (PlayerPrefs.GetInt("HardMode") == 1) {
			On = true;
			setOn();
		} else {
			On = false;
			setOff();		
		}
		
	}
	
	void OnMouseUp(){
		if (PlayerPrefs.GetInt ("LevelProgression") < 5) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = locked; //swap sprite
				} else {
				if (On) {
						setOn();
						PlayerPrefs.SetInt ("HardMode", 0); //save for next time
						On = false;
					} else { 
						setOff();
						gameObject.GetComponent<SpriteRenderer> ().sprite = onSprite; //swap sprite
						PlayerPrefs.SetInt ("HardMode", 1); //save for next time
						On = true;
						}
				}
	}

	void setLocked(){
		Vector3 scaler = new Vector3 (0.15f, 0.15f, 0);
		gameObject.GetComponent<SpriteRenderer> ().sprite = locked; //swap sprite
		gameObject.GetComponent<Transform>().localScale = scaler;
	}

	void setOn(){
		Vector3 scaler = new Vector3 (0.3207591f, 0.3207591f, 0);
		gameObject.GetComponent<SpriteRenderer> ().sprite = onSprite; //swap sprite
		gameObject.GetComponent<Transform> ().localScale = scaler;

	}

	void setOff(){
		Vector3 scaler = new Vector3 (0.3207591f, 0.3207591f, 0);
		gameObject.GetComponent<SpriteRenderer> ().sprite = offSprite; //swap sprite
		gameObject.GetComponent<Transform> ().localScale = scaler;
	}
}
