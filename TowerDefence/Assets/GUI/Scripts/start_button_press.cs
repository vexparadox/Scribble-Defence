using UnityEngine;
using System.Collections;

public class start_button_press : MonoBehaviour {

	public Sprite button;
	public Sprite button_down;

	void OnMouseEnter(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = button_down;
	}
	void OnMouseExit(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = button;
	}
	void OnMouseDown(){
		Application.LoadLevel ("Level1");
	}
}
