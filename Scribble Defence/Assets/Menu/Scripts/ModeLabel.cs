using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModeLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("HardMode") == 1) {
			gameObject.GetComponent<Text>().text = "Hard Mode";
				} else {
			gameObject.GetComponent<Text>().text = "Normal Mode";
			}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
