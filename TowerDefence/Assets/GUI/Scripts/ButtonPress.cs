using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
	public string level_to_load;
	public Sprite button;
	public Sprite button_down;

	void OnMouseEnter(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = button_down;
	}
	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = button;
	}
	void OnMouseDown(){
		Application.LoadLevel (level_to_load);
	}
}
