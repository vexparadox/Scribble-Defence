#pragma strict
var CurrentShortestObject: Transform;
var debugger: Transform;

function Start () {

FindNearest();
 transform.LookAt(CurrentShortestObject.transform.position);
 Debug.Log(debugger.position);
 Debug.Log(debugger.rotation);
}

function Update () {


}

function FindNearest(){

 var EnemyFinder = GameObject.FindGameObjectsWithTag("Enemy"); 
 var CurrentShortestDist = 9999;
 
 for (var i = 0 ; i<EnemyFinder.length ; i++){
  var TryingEnemy = EnemyFinder[i].transform.position;
 var TryingDistance = 99999;
 TryingDistance= Vector3.Distance(TryingEnemy, transform.localPosition);
 	if(TryingDistance<CurrentShortestDist){
  CurrentShortestObject = EnemyFinder[i].transform;
     CurrentShortestDist=TryingDistance;
     Debug.Log(CurrentShortestObject);
  }
   }
} 