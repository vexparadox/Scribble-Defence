using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	public Text Value1, Value2,Value3,Value4,Value5;
	public Text Level1, Level2,Level3,Level4,Level5;
	// Use this for initialization
	void Start () {
	
		UpdateTextHighscoreUI ();
	}

	void UpdateTextHighscoreUI(){
		// update the TextUI to the current currency
		Value1.text = PlayerPrefs.GetInt("Top1").ToString();
		Value2.text = PlayerPrefs.GetInt("Top2").ToString();
		Value3.text = PlayerPrefs.GetInt("Top3").ToString();
		Value4.text = PlayerPrefs.GetInt("Top4").ToString();
		Value5.text = PlayerPrefs.GetInt("Top5").ToString();


		Level1.text = PlayerPrefs.GetString("Value1");
		Level2.text = PlayerPrefs.GetString("Value2");
		Level3.text = PlayerPrefs.GetString("Value3");
		Level4.text = PlayerPrefs.GetString("Value4");
		Level5.text = PlayerPrefs.GetString("Value5");


	}

}
