#pragma strict
var gruntWaves: int[];
public var numberOfWaves = 1;
public var gruntEnemy:GameObject;
private var currentWaveAmount = 0;
private var currentWave = 0;

function Start () {
	//grunt waves holds the amount of grunts in each wave
	gruntWaves = new int[numberOfWaves];
	for (var i = 0; i < numberOfWaves; i++){
	//formula can be changed
		gruntWaves[i] = (i*2)+3;
	}
	Debug.Log(gruntWaves[0]);
}

function Update () {
	if (Input.GetKeyDown ("space")){
		SpawnGrunt();
	}
}

function SpawnGrunt(){
	//Using a while loop seems to fix the non spawning issue, it was a logic problem.... I think
	//while there are less enemies than expected keep spawning them
	while(currentWaveAmount<gruntWaves[currentWave]){
		Debug.Log(currentWaveAmount);
		//create the enemy
		Instantiate(gruntEnemy, Vector2(currentWaveAmount,currentWaveAmount), Quaternion.identity);
		//increase the number of enemyes on screen
		currentWaveAmount++;
		//wait for respawn time
		yield WaitForSeconds(2);
	}
}