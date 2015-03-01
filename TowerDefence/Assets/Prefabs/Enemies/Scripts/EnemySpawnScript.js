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
			gruntsPerWave[i] = 5;
		} else{
			gruntsPerWave[i] = i*5;
		}
		tanksPerWave[i] = 5;
		speedyPerWave[i] = i;
	}
	Spawn();
}

function Spawn(){
	while(!roundOver){
	var rndChance = parseInt(Random.Range(0,2));
	
	if(rndChance == 0){
		if(currentGruntCount<gruntsPerWave[currentWave]){
			var newGruntEnemy:GameObject;
			newGruntEnemy = Instantiate(gruntEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
			newGruntEnemy.transform.parent = enemyParentObject.transform;
			currentGruntCount++;
		} else { rndChance++; }
	} else if(rndChance == 1){
		if(currentTankCount<tanksPerWave[currentWave]){
			var newTankEnemy:GameObject;
			newTankEnemy = Instantiate(tankEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
			newTankEnemy.transform.parent = enemyParentObject.transform;
			currentTankCount++;
		}
	}
	yield WaitForSeconds(timeBetweenEnemies);
}

}