#pragma strict
var gruntWaves: int[];
public var numberOfWaves = 1;
public var gruntEnemy:GameObject;
var currentWaveAmount = 0;
var currentWave = 0;

function Start () {
gruntWaves = new int[numberOfWaves];
gruntWaves[0] = 5;

}

function Update () {
SpawnGrunt();
}

function SpawnGrunt(){
if(currentWaveAmount<gruntWaves[currentWave]){
Debug.Log(currentWaveAmount);
Instantiate(gruntEnemy, Vector2(currentWaveAmount,currentWaveAmount), Quaternion.identity);
currentWaveAmount++;
yield WaitForSeconds(10);
}
}