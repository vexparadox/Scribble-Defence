using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyScript : MonoBehaviour {
	public int CurrentCurrency; //the current currecny, this is updated throughout the game - can later be private
	public int StartCurrency; // this is the start currency of the level

	public int[] EnemyWorth = new int[4]; // this is how much the user gets for each enemy kill
	// element 0 = Grunt, 1 = Tank, 2 = Speedy, 3 = Boss
	public int[] TowerCost = new int[4]; // this is how much each tower costs to place, element 0 = tower 1 etc.
 	public Text CurrencyLabel; // this is the Text object that holds the currecny label
	public Text[] TowerCostLabel = new Text[4];

	void Start(){
		CurrentCurrency = StartCurrency; //assign the start currency
		UpdateTextCookiesUI(); // update the TextUI to the current currency
		UpdateTextTowerCost ();
	}

	void enemyDead(int EnemyID){
		//depending on what enemy is killed, add their worth to the currency
		//enemy worth is defined publically in the _GM game object
		CurrentCurrency += EnemyWorth[EnemyID]; 

		UpdateTextCookiesUI(); // update the TextUI to the current currency
	}

	void UpdateTextCookiesUI(){
		// update the TextUI to the current currency
		CurrencyLabel.text = "Cookies: " + CurrentCurrency;
	}

	void UpdateTextTowerCost(){
		GameObject temp = null; 
		//find all the towerCost Text Objects
		for (int i =0; i < TowerCostLabel.Length; i++) {
			temp = GameObject.Find("TowerCost"+(i+1));
			//get the Text Component from the Temp object
			TowerCostLabel[i] = temp.GetComponent<Text>();
			}
		//assign the tower cost labels to their costs
		for (int i =0; i < TowerCostLabel.Length; i++) {
			TowerCostLabel[i].text = TowerCost[i] + " Cookies";
			}
		temp = null;
	}
}
