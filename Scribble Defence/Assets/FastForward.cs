using UnityEngine;
using System.Collections;

public class FastForward : MonoBehaviour {

	void OnMouseDown(){
		Time.timeScale = 2.5f;
	}

	void OnMouseUp(){
		Time.timeScale = 1;
	}
}
