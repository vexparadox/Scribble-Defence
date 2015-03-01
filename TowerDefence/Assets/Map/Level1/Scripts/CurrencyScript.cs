using UnityEngine;
using System.Collections;

public class CurrencyScript : MonoBehaviour {
	public int CurrentCurrency;
	public int StartCurrency;
	public int GruntWorth, TankWorth, SpeedyWorth, BossWorth;
	public int Tower1Cost, Tower2Cost, Tower3Cost, Tower4Cost;
	void Start(){
		CurrentCurrency = StartCurrency;
	}

	void enemyDead(string EnemyName){
		Debug.Log (EnemyName);
		if (EnemyName == "Grunt") {
			CurrentCurrency += GruntWorth;
		} else if (EnemyName == "Tank") {
			CurrentCurrency += TankWorth;
		} else if (EnemyName == "Speedy") {
			CurrentCurrency += SpeedyWorth;
		} else if (EnemyName == "Boss") {
			CurrentCurrency += BossWorth;
		}
		 
	}
}
