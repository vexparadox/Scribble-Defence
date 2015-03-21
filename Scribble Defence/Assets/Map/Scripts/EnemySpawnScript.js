#pragma strict
import UnityEngine.UI;

//holds the amount of enemies per[wave]
private var gruntsPerWave: int[];
private var tanksPerWave: int[];
private var speedPerWave: int[];
private var bossPerWave: int[];

public var enemyParentObject:GameObject; // this is what all enemies will be a child of
public var SpawnPoint:Transform; // this is the spawn point of all the enemies

public var gruntEnemyPrefab:GameObject; // this is the objet that is the enemy
public var tankEnemyPrefab:GameObject;
public var bossEnemyPrefab:GameObject;
public var speedEnemyPrefab:GameObject;

public var timeBetweenEnemies: int; //hold the respawn time between enemies
public var timeBetweenWaves: int; //holds the time between waves
public var numberOfWaves: int; // this is the number of waves that will occur

public var waveTextLabel: Text; // holds the Current Wave
private var totalEnemiesThisWave: int; // holds the maximum enemies in this wave
private var _GM: GameObject;

private var currentEnemyCount:int[] = new int[4]; // holds how many enemyies are alive
	//this 0,1,2,3 system is used throught the system
	/*
	0 = grunt
	1 = tank
	2 = speedy
	3 = boss
	*/

private var roundOver: boolean = false;
public var currentWave = 0; //the current wave we're on


function Start () {
	//initialse arrays of amounts of enemies
	gruntsPerWave = new int[numberOfWaves];
	tanksPerWave = new int[numberOfWaves];
	speedPerWave = new int[numberOfWaves];
	bossPerWave = new int[numberOfWaves];
	
	//find the game master
	_GM = GameObject.Find("_GM");
	
	//fill arrays with the amount of enemies per wave
	for(var i = 0; i < numberOfWaves; i++){
		if(i == 0){
			//on first wave have 10 grunts
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
	waveTextLabel.text = "Place now!";
	yield WaitForSeconds(timeBetweenWaves*2); //wait for the first one, double time on first one
	totalEnemiesThisWave = gruntsPerWave[currentWave] + tanksPerWave[currentWave] + speedPerWave[currentWave] + bossPerWave[currentWave]; //get the total enemies this wave
	Spawn();//start the spawning on first wave
	updateUI();
}

function Update(){
	checkForRoundEnd();
}

function Spawn(){
	while(!roundOver){
	var rndChance2 = parseInt(Random.Range(0,100)); // used for deciding tank or speedy
	var rndChance = parseInt(Random.Range(0,100))+20; //used for deciding grunt or tank/speedy
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
	
	yield WaitForSeconds(timeBetweenEnemies); //wait for time before enemies
	}
}
 //spawn a grunt
function SpawnGrunt(){
		var newEnemy:GameObject;
		//create the enemy game object
		newEnemy = Instantiate(gruntEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; //put into enemy parent
		currentEnemyCount[0]++; //add one to the tally
}
//spawn a tank
function SpawnTank(){
		var newEnemy:GameObject;
		//create the enemy game object
		newEnemy = Instantiate(tankEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; // put into enemy paretn
		currentEnemyCount[1]++; //add one to the tally
}

function SpawnSpeed(){
		var newEnemy:GameObject;
		//create the enemy game object
		newEnemy = Instantiate(speedEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; // put into enemy paretn
		currentEnemyCount[2]++; //add one to the tally
}

function SpawnBoss(){
		var newEnemy:GameObject;
		//create the enemy game object
		newEnemy = Instantiate(bossEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform; // put into enemy paretn
		currentEnemyCount[3]++; //add one to the tally
}




//function takes enemy death and marks it
function enemyDead(){
	totalEnemiesThisWave--; //take an enemy away depending on the ID
}


function checkForRoundEnd(){
//if all are dead and there're are none to spawn && they're all dead
	if(currentEnemyCount[0]==gruntsPerWave[currentWave] && 
	currentEnemyCount[1]==tanksPerWave[currentWave] && 
	currentEnemyCount[2] == speedPerWave[currentWave] &&
	currentEnemyCount[3] == bossPerWave[currentWave] && 
	totalEnemiesThisWave == 0){
	
		roundOver = true; // stop more spawning
		if (currentWave != numberOfWaves){ // if it's not the last wave
			currentWave++; //advance a wave
			totalEnemiesThisWave = gruntsPerWave[currentWave] + tanksPerWave[currentWave] + speedPerWave[currentWave] + bossPerWave[currentWave]; //get new total enemies
			//wipe current enemy array, this allows more spawning
			for (var i =0; i < currentEnemyCount.length; i++){
				currentEnemyCount[i] = 0;
			}
			yield WaitForSeconds(timeBetweenWaves); //wait for time before waves
			roundOver = false; // staart spawning again 
			Spawn(); //call spawn
			updateUI();
			Debug.Log("New wave");
		} else{
			//level won 
			_GM.SendMessage("levelWon");
		}
	}
}

function updateUI(){
	waveTextLabel.text = "Wave: " + (currentWave+1) + "/" +numberOfWaves; // set wave text label

}
