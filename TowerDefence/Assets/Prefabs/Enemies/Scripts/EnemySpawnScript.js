#pragma strict
//We can either have a different script for each enemy type, or have multiple functions in one script both of these are fine
private var gruntWaves: int[]; // deals with the 
public var enemyParentObject:GameObject; // this is what all enemies will be a child of
public var SpawnPoint:Transform; // this is the spawn point of all the enemies
public var gruntEnemyPrefab:GameObject; // this is the objet that is the enemy

public var timeBetweenEnemies:int; //hold the respawn time between enemies
public var numberOfWaves = 1; // this is the number of waves that will occur
private var currentWaveAmount = 0; // the current amount of enemies in a wave - this will have to be seperate for 
private var currentWave = 0; //the current wave we're on

function Start () {
	//grunt waves holds the amount of grunts in each wave
	gruntWaves = new int[numberOfWaves];
	for (var i = 0; i < numberOfWaves; i++){
	//formula can be changed
		gruntWaves[i] = (i*2)+3;
	}
	//spawn the grunts on launch
	SpawnGrunt();
}

function SpawnGrunt(){
	//holds the new enemy so we can make
	var newEnemy:GameObject;
	//Using a while loop seems to fix the non spawning issue, it was a logic problem.... I think
	//while there are less enemies than expected keep spawning them
	while(currentWaveAmount<gruntWaves[currentWave]){
		Debug.Log(currentWaveAmount);
		//create the enemy at the spawn point
		newEnemy = Instantiate(gruntEnemyPrefab, Vector2(SpawnPoint.position.x, SpawnPoint.position.y), Quaternion.identity);
		newEnemy.transform.parent = enemyParentObject.transform;
		//increase the number of enemyes on screen
		currentWaveAmount++;
		//wait for respawn time
		yield WaitForSeconds(timeBetweenEnemies);
	}
}