using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	//holds the amount of enemies per[wave]
	private int[] gruntsPerWave;
	private int[] tanksPerWave;
	private int[] speedPerWave;
	private int[] bossPerWave;
	
	public GameObject enemyParentObject; // this is what all enemies will be a child of
	public Transform SpawnPoint; // this is the spawn point of all the enemies
	
	public GameObject gruntEnemyPrefab; // this is the objet that is the enemy
	public GameObject tankEnemyPrefab;
	public GameObject bossEnemyPrefab;
	public GameObject speedEnemyPrefab;
	
	public int timeBetweenEnemies; //hold the respawn time between enemies
	public int timeBetweenWaves; //holds the time between waves
	public int numberOfWaves; // this is the number of waves that will occur
	
	public Text waveTextLabel; // holds the Current Wave
	private int totalEnemiesThisWave; // holds the maximum enemies in this wave
	private GameObject _GM;
	
	private int[] currentEnemyCount = new int[4]; // holds how many enemyies are alive
	//this 0,1,2,3 system is used throught the system
	/*
	0 = grunt
	1 = tank
	2 = speedy
	3 = boss
	*/
	
	private bool  roundOver = false;
	public int currentWave= 0; //the current wave we're on
	
	
	void Start (){
		//initialse arrays of amounts of enemies
		gruntsPerWave = new int[numberOfWaves];
		tanksPerWave = new int[numberOfWaves];
		speedPerWave = new int[numberOfWaves];
		bossPerWave = new int[numberOfWaves];
		
		//find the game master
		_GM = GameObject.Find("_GM");
		
		//fill arrays with the amount of enemies per wave
		for(int i= 0; i < numberOfWaves; i++){
			if(i == 0){
				//on first wave have 10 grunt
				gruntsPerWave[i] = 10;
				tanksPerWave[i] = 0;
				speedPerWave[i] = 0;
			} else{
				//each time increase number of enemies
				gruntsPerWave[i] = (i+1)*8;
				tanksPerWave[i] = (i+1)*3;
				speedPerWave[i] = 0;
			}
			
			if(i >= 3){
				speedPerWave[i] = (i+1)*5; // 0 to keep the waves advancing
				if(i >= numberOfWaves-1){
					bossPerWave[i] = 2; //2 bosses on last wave
				}else{ 
					bossPerWave[i] = 1; //one on everything after 2nd wave
				}
			} else{
				bossPerWave[i] = 0;
			}
		}
		placementWave();
		Spawn();
	}
	
	void  Update (){
		checkForRoundEnd();
	}

	void placementWave(){
		waveTextLabel.text = "Place now!";
		updateUI ();
		totalEnemiesThisWave = gruntsPerWave[currentWave] + tanksPerWave[currentWave] + speedPerWave[currentWave] + bossPerWave[currentWave]; //get the total enemies this wave
		StartCoroutine (waiter (timeBetweenWaves * 2));
	}

	IEnumerator waiter(int waittime){
		yield return new WaitForSeconds(waittime); //wait for the given amount of time
	}
	
	void Spawn (){
		while(!roundOver){
			int rndChance2 = (int)Random.Range(0,100); // used for deciding tank or speedy
			int rndChance = (int)Random.Range(0,100)+20; //used for deciding grunt or tank/speedy
			if(rndChance > 50){ //if it's a grunt, spawn it
				if(currentEnemyCount[0]<gruntsPerWave[currentWave]){
					SpawnGrunt(); //if there's grunts left to play, do it
				} else if(currentEnemyCount[1]<tanksPerWave[currentWave]){
					SpawnTank(); // if there's not any more, play a tank (if there's any left)
				} 
			} else if(rndChance < 50){ //if it's not a grunt spawn a speedy/tank
				if(rndChance2 >50){
					if(currentEnemyCount[2] < speedPerWave[currentWave]){
						SpawnSpeed();
					} else if(currentEnemyCount[0]<gruntsPerWave[currentWave]){
						SpawnGrunt();
					} else if(currentEnemyCount[1]<tanksPerWave[currentWave]){
						SpawnTank();
					}
				}else{
					//spawn tank
					if(currentEnemyCount[1]<tanksPerWave[currentWave]){
						SpawnTank(); //if there's tanks left to play do it
					} else if(currentEnemyCount[0]<gruntsPerWave[currentWave]){
						SpawnGrunt(); //else if not, play a grunt instead (if there's any left)
					} else if(currentEnemyCount[2] < speedPerWave[currentWave]){
						SpawnSpeed();
					}
				}
			}
			
			//if they're all spawned, spawn the bosses
			if(currentEnemyCount[0] >= gruntsPerWave[currentWave]
			   && currentEnemyCount[1] >= tanksPerWave[currentWave] 
			   && currentEnemyCount[2] >= speedPerWave[currentWave]
			   && currentEnemyCount[3] < bossPerWave[currentWave]){
				SpawnBoss();
			}
			
			StartCoroutine(waiter(timeBetweenEnemies)); //wait for time before enemies
		}
	}
	//spawn a grunt
	void  SpawnGrunt (){
		GameObject newEnemy;
		//create the enemy game object
		newEnemy = (GameObject)Instantiate(gruntEnemyPrefab, new Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; //put into enemy parent
		currentEnemyCount[0]++; //add one to the tally
	}
	//spawn a tank
	void  SpawnTank (){
		GameObject newEnemy;
		//create the enemy game object
		newEnemy = (GameObject)Instantiate(tankEnemyPrefab, new Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; // put into enemy paretn
		currentEnemyCount[1]++; //add one to the tally
	}
	
	void  SpawnSpeed (){
		GameObject newEnemy;
		//create the enemy game object
		newEnemy = (GameObject)Instantiate(speedEnemyPrefab, new Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; // put into enemy paretn
		currentEnemyCount[2]++; //add one to the tally
	}
	
	void  SpawnBoss (){
		GameObject newEnemy;
		//create the enemy game object
		newEnemy = (GameObject)Instantiate(bossEnemyPrefab, new Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; // put into enemy paretn
		currentEnemyCount[3]++; //add one to the tally
	}
	
	
	
	
	//function takes enemy death and marks it
	void  enemyDead (){
		totalEnemiesThisWave--; //take an enemy away depending on the ID
	}
	
	
	void checkForRoundEnd (){
		//if all are dead and there're are none to spawn && they're all dead
		if(currentEnemyCount[0]==gruntsPerWave[currentWave] && 
		   currentEnemyCount[1]==tanksPerWave[currentWave] && 
		   currentEnemyCount[2] == speedPerWave[currentWave] &&
		   currentEnemyCount[3] == bossPerWave[currentWave] && 
		   totalEnemiesThisWave == 0){
			
			roundOver = true; // stop more spawning
			if (currentWave+1 != numberOfWaves){ // if it's not the last wave
				currentWave++; //advance a wave
				totalEnemiesThisWave = gruntsPerWave[currentWave] + tanksPerWave[currentWave] + speedPerWave[currentWave] + bossPerWave[currentWave]; //get new total enemies
				//wipe current enemy array, this allows more spawning
				for (int i=0; i < currentEnemyCount.Length; i++){
					currentEnemyCount[i] = 0;
				}
				StartCoroutine(waiter(timeBetweenWaves)); //wait for time before waves
				roundOver = false; // staart spawning again 
				Spawn(); //call spawn
				updateUI();
				Debug.Log("New wave");
			} else{
				//level won
				waveTextLabel.text = "Completed!";
				Time.timeScale = 0;
				_GM.SendMessage("levelWon"); //start out the new level
			}
		}
	}
	
	void  updateUI (){
		waveTextLabel.text = "Wave: " + (currentWave+1) + "/" +numberOfWaves; // set wave text label
		
	}
	
}