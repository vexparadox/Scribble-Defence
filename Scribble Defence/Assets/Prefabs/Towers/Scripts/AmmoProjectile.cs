using UnityEngine;
using System.Collections;

public class AmmoProjectile : MonoBehaviour {
	
	Transform CurrentShortestObject; //holds the closest objects transform
	public float bulletspeed; //holds the bullet speed
	
	//THESE ARE DO NOT WORK IF SET IN THE EDITOR, USE THE TOWERSCRIPT.JS TO SET DAMAGES
	[HideInInspector]
		public int aoe; // holds AOE range on towers * is now on Tower Script
	[HideInInspector]
		public bool  onscreen; //if the bullets are onscreen or not
	[HideInInspector]
		public int towerLevel;	//holds the tower level
	[HideInInspector]
		public float attackDmg;//attack damage is now stored in the TowerScript
	
	void  Start (){
		FindNearest();//get the nearest object
		Vector2 dir = CurrentShortestObject.transform.position - transform.position; // See Below
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; // See Below
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Thanks to http://answers.unity3d.com/questions/654222/make-sprite-look-at-vector2-in-unity-2d-1.html for the lookat alternative
		towerLevel = 1;// initializes the tower level in 1
		float xforce= Mathf.Cos(rigidbody2D.rotation*Mathf.Deg2Rad+(Mathf.PI/2))*bulletspeed;
		float yforce= Mathf.Sin(rigidbody2D.rotation*Mathf.Deg2Rad+(Mathf.PI/2))*bulletspeed; // Use of SOHCAH to figure out how to apply the force correctly
		rigidbody2D.AddForceAtPosition(new Vector2(xforce,yforce), transform.position);
	}
	
	void  Update (){
		
		onscreen = renderer.isVisible;
		if(!onscreen){
			Destroy(gameObject);
		}
		
	}
	
	void  FindNearest (){
		GameObject[] EnemyFinder= GameObject.FindGameObjectsWithTag("Enemy"); 
		float CurrentShortestDist= 9999;
		
		for (int i= 0 ;  i < EnemyFinder.Length; i++){
			Vector2 TryingEnemy= EnemyFinder[i].transform.position;
			float TryingDistance = 99999;
			TryingDistance = Vector2.Distance(TryingEnemy, transform.localPosition);
			if(TryingDistance<CurrentShortestDist){
				CurrentShortestObject = EnemyFinder[i].transform;
				CurrentShortestDist=TryingDistance;
			}
		}
	} 
}