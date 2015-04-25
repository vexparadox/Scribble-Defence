#pragma strict
var CurrentShortestObject: Transform; //holds the closest objects transform
public var bulletspeed: float; //holds the bullet speed

//THESE ARE DO NOT WORK IF SET IN THE EDITOR, USE THE TOWERSCRIPT.JS TO SET DAMAGES
@HideInInspector
public var aoe : int; // holds AOE range on towers * is now on Tower Script
@HideInInspector
public var onscreen:boolean; //if the bullets are onscreen or not
@HideInInspector
public var towerLevel: int;	//holds the tower level
@HideInInspector
public var attackDmg : float;//attack damage is now stored in the TowerScript

function Start () {
	FindNearest();//get the nearest object
 	var dir = CurrentShortestObject.transform.position - transform.position; // See Below
 	var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // See Below
 	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Thanks to http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html for the lookat alternative
	towerLevel = 1;// initializes the tower level in 1
  	var xforce = Mathf.Cos(rigidbody2D.rotation*Mathf.Deg2Rad+(Mathf.PI/2))*bulletspeed;
 	var yforce = Mathf.Sin(rigidbody2D.rotation*Mathf.Deg2Rad+(Mathf.PI/2))*bulletspeed; // Use of SOHCAH to figure out how to apply the force correctly
 	rigidbody2D.AddForceAtPosition(new Vector2(xforce,yforce), transform.position);
 }

function Update () {

	onscreen = renderer.isVisible;
	if(!onscreen){
		Destroy(gameObject);
	}
	
}

function FindNearest(){
	
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
} 