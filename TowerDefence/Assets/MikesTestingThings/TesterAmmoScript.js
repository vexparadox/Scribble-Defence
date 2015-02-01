#pragma strict
var CurrentShortestObject : Transform;


function Start () {
 transform.LookAt(FindNearest());
}

function Update () {

}

function FindNearest(){

 var EnemyFinder = GameObject.FindGameObjectsWithTag("Enemy"); 
 var CurrentShortestDist = 999999999999;
 
 for (var i = 0 ; i<EnemyFinder.length ; i++){
  var TryingEnemy = EnemyFinder[i].transform.position;
 var TryingDistance = 999999999999999999;
 TryingDistance= Vector3.Distance(TryingEnemy, transform.localPosition);
 	if(TryingDistance<CurrentShortestDist){
  CurrentShortestObject = TryingEnemy;
     CurrentShortestDist=TryingDistance;
  }
   }
   return CurrentShortestObject;
} 