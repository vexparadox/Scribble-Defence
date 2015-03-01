using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyScript : MonoBehaviour {
	public int CurrentCurrency; //the current currecny, this is updated throughout the game - can later be private
	public int StartCurrency; // this is the start currency of the level

	public int GruntWorth, TankWorth, SpeedyWorth, BossWorth; // this is how much the user gets for each enemy kill
	public int Tower1Cost, Tower2Cost, Tower3Cost, Tower4Cost; // this is how much each tower costs to place
	public Text CurrencyLabel; // this is the Text object that holds the currecny label

	void Start(){
		CurrentCurrency = StartCurrency; //assign the start currency
		UpdateTextUI(); // update the TextUI to the current currency
	}

	void enemyDead(string EnemyName){
		Debug.Log (EnemyName); // debug what enemy has been killed

		//depending on what enemy is killed, add their worth to the currency
		//enemy worth is defined publically in the _GM game object
		if (EnemyName == "Grunt") {
			CurrentCurrency += GruntWorth;
		} else if (EnemyName == "Tank") {
			CurrentCurrency += TankWorth;
		} else if (EnemyName == "Speedy") {
			CurrentCurrency += SpeedyWorth;
		} else if (EnemyName == "Boss") {
			CurrentCurrency += BossWorth;
		}
		UpdateTextUI(); // update the TextUI to the current currency
	}

	void UpdateTextUI(){
		// update the TextUI to the current currency
		CurrencyLabel.text = "Cookies: " + CurrentCurrency;
	}
}
