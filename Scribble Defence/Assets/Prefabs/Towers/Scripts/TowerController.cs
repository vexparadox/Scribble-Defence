using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {
	
	private Transform CurrentShortestObject;
	public GameObject TowerAmmo;
	public int Range;
	public float Reload;
	public bool hasShot= false;
	public bool  isPlaced = false; // tells the Interface Script if the tower was placed or not
	//tower variables
	public int towerLevel = 1;
	public int upgradeCost;
	public float attackDamage;
	public int aoeRange;
	public int towerDamageInc =1;
	public int ID;
	public int baseID;
	
	
	
	void Update (){
		findNearest();
		if(CurrentShortestObject!=null){
			Turn();
			StartCoroutine(fire());	
		}
	}
	
	void Shoot(){
		//only play sounds if the soundFX's have been turned on
		if(PlayerPrefs.GetInt("SoundFX") == 1){
			audio.Play();
		}
		GameObject clone;
		clone = (GameObject)Instantiate(TowerAmmo, transform.localPosition, Quaternion.identity); //Create bullet
		
		//set up the ammo's damage and AOE
		AmmoProjectile bullet;
		bullet = clone.GetComponent<AmmoProjectile>();
		bullet.attackDmg = attackDamage;
		bullet.aoe = aoeRange;
	}
	
	void Turn (){
		if(Range>Vector2.Distance(CurrentShortestObject.transform.position, transform.localPosition)){
			Vector2 dir = CurrentShortestObject.transform.position - transform.position; // See Below
			float angle= Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // See Below
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Thanks to http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html for the lookat alternative
		}
	}

	void findNearest (){
		isPlaced = true;
		GameObject[] EnemyFinder= GameObject.FindGameObjectsWithTag("Enemy"); //Find all enemies
		float CurrentShortestDist= 999999; // Set current distance to one stupidly high to ensure it doesn't fire on accident
		
		for (int i= 0 ; i<EnemyFinder.Length ; i++){
			Vector2 TryingEnemy= EnemyFinder[i].transform.position;
			float TryingDistance = 999999;
			TryingDistance= Vector2.Distance(TryingEnemy, transform.localPosition); // find the distance between the tower and the enemy beind tested
			if(TryingDistance<CurrentShortestDist){ //If the distance is the shorter than the current shortest  then swap the values to the shorter one
				CurrentShortestObject = EnemyFinder[i].transform;
				CurrentShortestDist=TryingDistance;
			}
		}
	}

	IEnumerator fire(){
		if(!hasShot){
			if(Range>Vector2.Distance(CurrentShortestObject.transform.position, transform.localPosition)){ //Check if the shortest enemy is in range
				hasShot=true; //Stop any more shots trying to happen
				Shoot(); //Actually shoot
				yield return new WaitForSeconds(Reload);//Wait until it has reloaded
				hasShot=false; // Allow shooitng again
			}
		}
	}

	//gets the base the tower is currently on
	void setBase (int baseID){
		this.baseID = baseID;
	}
}