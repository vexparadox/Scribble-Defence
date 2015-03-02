#pragma strict
//We can either have a different script for each enemy type, or have multiple functions in one script both of these are fine
/*
These 2D arrays hold [waveNumber][perWave];
*/
private var gruntsPerWave: int[];
private var tanksPerWave: int[];
private var speedyPerWave: int[];

public var enemyParentObject:GameObject; // this is what all enemies will be a child of
public var SpawnPoint:Transform; // this is the spawn point of all the enemies

public var gruntEnemyPrefab:GameObject; // this is the objet that is the enemy
public var tankEnemyPrefab:GameObject;
public var bossEnemyPrefab:GameObject;
public var speedEnemyPrefab:GameObject;

public var timeBetweenEnemies: int; //hold the respawn time between enemies
public var timeBetweenWaves: int; //holds the time between waves
public var numberOfWaves: int; // this is the number of waves that will occur


public var currentEnemyCount:int[] = new int[4]; // holds how many enemyies are alive
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
	gruntsPerWave = new int[numberOfWaves];
	tanksPerWave = new int[numberOfWaves];
	speedyPerWave = new int[numberOfWaves];
	
	for(var i = 0; i < numberOfWaves; i++){
		if(i == 0){
			gruntsPerWave[i] = 10;
			tanksPerWave[i] = 2;
		} else{
			gruntsPerWave[i] = i*6;
			tanksPerWave[i] = i*3;
		}
	}
	yield WaitForSeconds(timeBetweenWaves);
	Spawn();
}

function Update(){
	checkForRoundEnd();
}

function Spawn(){
	while(!roundOver){
	var rndChance = parseInt(Random.Range(0,100))+20;
	if(rndChance > 50){
		if(currentEnemyCount[0]<gruntsPerWave[currentWave]){
			SpawnGrunt(); //if there's grunts left to play, do it
		} else if(currentEnemyCount[1]<tanksPerWave[currentWave]){
					SpawnTank(); // if there's not any more, play a tank (if there's any left)
				} 
	} else if(rndChance < 50){
		if(currentEnemyCount[1]<tanksPerWave[currentWave]){
			SpawnTank(); //if there's tanks left to play do it
		} else if(currentEnemyCount[0]<gruntsPerWave[currentWave]){
			SpawnGrunt(); //else if not, play a grunt instead (if there's any left)
			}
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

//function takes enemy death and marks it
function enemyDead(enemyID){
	currentEnemyCount[enemyID]--; //take an enemy away depending on the ID
}


//boolean function returns if all enemies are dead or not
function allDead(){
	var currentEmpty:int; // this holds how many types of enemies are dead
	for( var i:int = 0; i < currentEnemyCount.Length; i++){
		if(currentEnemyCount[i] == 0){
			currentEmpty = 0; //mark this one as empty
		}
	 } 
	 
	if (currentEmpty == 0){
		return true; //if they're all empty (dead) return true
	} else{
		return false;
	}
}

function checkForRoundEnd(){
//if all are dead and there're are none to spawn
	if(currentEnemyCount[0]==gruntsPerWave[currentWave] && currentEnemyCount[1]==tanksPerWave[currentWave] && allDead){
		roundOver = true; // stop more spawning
		currentWave++; //advance a wave
		yield WaitForSeconds(timeBetweenWaves); //wait for time before waves
		roundOver = false; // start spawning again 
		Spawn(); //call spawn
	}
}