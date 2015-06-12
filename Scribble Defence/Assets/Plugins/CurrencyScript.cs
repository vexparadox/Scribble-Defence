using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyScript : MonoBehaviour {
	public int CurrentCurrency; //the current currecny, this is updated throughout the game - can later be private
	public int StartCurrency; // this is the start currency of the level
	
	//public string HighScore = "HighScoreCurrency";
	public int score = 0;
	public static int counter = 0;
	public int[] top5Scores;
	public int[] TowerCost = new int[4]; // this is how much each tower costs to place, element 0 = tower 1 etc.
	public Text CurrencyLabel; // this is the Text object that holds the currecny label
	public Text[] TowerCostLabel = new Text[4];
	
	
	public Text HighScore;
	
	void Start(){

		//PlayerPrefs.DeleteAll ();
		if (PlayerPrefs.HasKey ("Counter")) {
			counter = PlayerPrefs.GetInt ("Counter");
		} else {
			PlayerPrefs.SetInt("Counter",0);
			counter = PlayerPrefs.GetInt ("Counter");
		}
		
		//if its the first time we create the keys with the top5 otherwise we see whether the
		//last score is in top5 or not
		if (counter == 0){
			for(int i=1;i<6;i++){
				PlayerPrefs.SetInt("Top"+i,0);
				PlayerPrefs.SetString("Value"+i,"Nothing");
			}
			PlayerPrefs.SetString("LastLevelPlayed","NoLEvel");


			
		} else {
			//if its bigger than the last then we see where the new score is in the top5
			if(PlayerPrefs.GetInt("BestScore") > PlayerPrefs.GetInt("Top5")){
				int i = 1;
				while(PlayerPrefs.GetInt("BestScore") < PlayerPrefs.GetInt("Top"+i)){
					
					i++;
				}
				if(PlayerPrefs.GetInt("BestScore") >= PlayerPrefs.GetInt("Top"+i)){
					int replaced = PlayerPrefs.GetInt("Top"+i);
					string stReplaced = PlayerPrefs.GetString("Value"+i);
					PlayerPrefs.SetInt("Top"+i, PlayerPrefs.GetInt("BestScore") );

					PlayerPrefs.SetString("Value"+i,PlayerPrefs.GetString("LastLevelPlayed"));
					
					while(replaced > PlayerPrefs.GetInt("Top"+(i+1)) && i<6){
						int newReplaced = PlayerPrefs.GetInt("Top"+(i+1));
						string newStReplaced = PlayerPrefs.GetString("Value"+(i+1));
						PlayerPrefs.SetInt("Top"+(i+1), replaced);
						PlayerPrefs.SetString("Value"+(i+1), stReplaced);
						replaced = newReplaced;
						stReplaced = newStReplaced;
						i++;
					}
				}
			}
		}
		PlayerPrefs.SetInt ("BestScore", 0);
		//PlayerPrefs.SetInt("HighScoreCurrency", 100);
		CurrentCurrency = StartCurrency; //assign the start currency
		//CurrentCurrency = PlayerPrefs.GetInt("HighScoreCurrency");
		UpdateTextCookiesUI(); // update the TextUI to the current currency
		UpdateTextTowerCost();
		counter++;
		PlayerPrefs.SetInt ("Counter", counter);
	}
	
	

	
	public void deadCash(int enemyWorth){
		//the enemyWorth is passed into the function, this is then added to the overall currency
		CurrentCurrency += enemyWorth;
		
		UpdateTextCookiesUI(); // update the TextUI to the current currency
		
		//we are looking at the current besyScore so we do counter-1 because after the start 
		//function the counter is increased by 1
		if (score > PlayerPrefs.GetInt("BestScore")) {
			//PlayerPrefs.SetInt("HighScore", score);
			PlayerPrefs.SetString("LastLevelPlayed",Application.loadedLevelName);
			PlayerPrefs.SetInt("BestScore", score);
			PlayerPrefs.Save();
		}
	}
	
	public void UpdateTextCookiesUI(){
		// update the TextUI to the current currency
		CurrencyLabel.text = CurrentCurrency.ToString();
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
			TowerCostLabel[i].text = TowerCost[i].ToString();
		}
		temp = null;
	}
	//is called to check is the tower can be afforded, and takes away cost from the total currency
	public bool CanAfford(int TowerID){
		if(TowerCost[TowerID] <= CurrentCurrency){ //if you can afford the tower
			CurrentCurrency -= TowerCost[TowerID]; //take cost of tower away
			UpdateTextCookiesUI(); // update the UI
			return true;
		}
		return false; //if you can't afford, return false
		
	}
}
