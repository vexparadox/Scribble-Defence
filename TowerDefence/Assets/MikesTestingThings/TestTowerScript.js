#pragma strict
var CurrentShortestObject: Transform;
public var TowerAmmo:GameObject;
public var Range = 90;
public var Reload = 5;
var hasShot = false;



function Update () {
Fire();	
}

function Shoot(){
 Debug.Log("Shot");
 Instantiate(TowerAmmo, transform.localPosition, Quaternion.identity);
 }
 
 function Fire(){
 if(!hasShot){
 var EnemyFinder = GameObject.FindGameObjectsWithTag("Enemy"); 
 var CurrentShortestDist = 9999;
 
	for (var i = 0 ; i<EnemyFinder.length ; i++){
  	var TryingEnemy = EnemyFinder[i].transform.position;
 	var TryingDistance = 99999;
 	TryingDistance= Vector2.Distance(TryingEnemy, transform.localPosition);
 		if(TryingDistance<CurrentShortestDist){
  			 CurrentShortestObject = EnemyFinder[i].transform;
    		 CurrentShortestDist=TryingDistance;
    	}
    }
     var dir = CurrentShortestObject.transform.position - transform.position; // See Below
 var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // See Below
 transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Thanks to http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html for the lookat alternative
	if(Range>Vector2.Distance(CurrentShortestObject.transform.position, transform.localPosition)){
	hasShot=true;
	Shoot();
	yield WaitForSeconds(Reload);
	hasShot=false;
	}
	}
} 