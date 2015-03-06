#pragma strict
var CurrentShortestObject: Transform;
public var TowerAmmo:GameObject;
public var Range = 90;
public var Reload:float;
var hasShot = false;



function Update () {
findNearest();
	if(CurrentShortestObject!=null){
		Turn();
		Fire();	
	}
}

function Shoot(){
 	Instantiate(TowerAmmo, transform.localPosition, Quaternion.identity); //Create bullet
}
 
 function Turn(){
	 if(Range>Vector2.Distance(CurrentShortestObject.transform.position, transform.localPosition)){
     var dir = CurrentShortestObject.transform.position - transform.position; // See Below
 	 var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // See Below
	 transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Thanks to http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html for the lookat alternative
	 }
 }
 function findNearest(){
 	var EnemyFinder = GameObject.FindGameObjectsWithTag("Enemy"); //Find all enemies
 	var CurrentShortestDist = 99999999; // Set current distance to one stupidly high to ensure it doesn't fire on accident
 
	for (var i = 0 ; i<EnemyFinder.length ; i++){
  	var TryingEnemy = EnemyFinder[i].transform.position;
 	var TryingDistance = 999999;
 	TryingDistance= Vector2.Distance(TryingEnemy, transform.localPosition); // find the distance between the tower and the enemy beind tested
 		if(TryingDistance<CurrentShortestDist){ //If the distance is the shorter than the current shortest  then swap the values to the shorter one
  			 CurrentShortestObject = EnemyFinder[i].transform;
    		 CurrentShortestDist=TryingDistance;
    	}
    }
 }
 function Fire(){
 	if(!hasShot){
 		if(Range>Vector2.Distance(CurrentShortestObject.transform.position, transform.localPosition)){ //Check if the shortest enemy is in range
			hasShot=true; //Stop any more shots trying to happen
			Shoot(); //Actually shoot
			yield WaitForSeconds(Reload);//Wait until it has reloaded
			hasShot=false; // Allow shooitng again
		}
	}
} 