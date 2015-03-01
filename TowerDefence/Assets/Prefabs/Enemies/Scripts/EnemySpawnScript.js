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
public var numberOfWaves: int; // this is the number of waves that will occur

private var currentGruntCount = 0; // the current amount of enemies in a wave - this will have to be seperate for 
private var currentTankCount = 0;
private var currentSpeedyCount = 0;

private var roundOver: boolean = false;
private var currentWave = 0; //the current wave we're on


function Start () {
	gruntsPerWave = new int[numberOfWaves];
	tanksPerWave = new int[numberOfWaves];
	speedyPerWave = new int[numberOfWaves];
	
	for(var i = 0; i < numberOfWaves; i++){
		if(i == 0){
			gruntsPerWave[i] = 10;
		} else{
			gruntsPerWave[i] = i*6;
		}
		tanksPerWave[i] = 2;
		speedyPerWave[i] = i*2;
	}
	Spawn();
}

function Update(){
	if(currentGruntCount==gruntsPerWave[currentWave] && currentTankCount==tanksPerWave[currentWave]){
		roundOver = true;
	}
}

function Spawn(){
	while(!roundOver){
	var rndChance = parseInt(Random.Range(0,100))+20;
	if(rndChance > 50){
		if(currentGruntCount<gruntsPerWave[currentWave]){
			SpawnGrunt(); //if there's grunts left to play, do it
		} else if(currentTankCount<tanksPerWave[currentWave]){
					SpawnTank(); // if there's not any more, play a tank (if there's any left)
				} 
	} else if(rndChance < 50){
		if(currentTankCount<tanksPerWave[currentWave]){
			SpawnTank(); //if there's tanks left to play do it
		} else if(currentGruntCount<gruntsPerWave[currentWave]){
			SpawnGrunt(); //else if not, play a grunt instead (if there's any left)
			}
	}
	yield WaitForSeconds(timeBetweenEnemies);
	}
}

function SpawnGrunt(){
		var newGruntEnemy:GameObject;
		newGruntEnemy = Instantiate(gruntEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newGruntEnemy.transform.parent = enemyParentObject.transform;
		currentGruntCount++;
}

function SpawnTank(){
		var newTankEnemy:GameObject;
		newTankEnemy = Instantiate(tankEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newTankEnemy.transform.parent = enemyParentObject.transform;
		currentTankCount++;
}