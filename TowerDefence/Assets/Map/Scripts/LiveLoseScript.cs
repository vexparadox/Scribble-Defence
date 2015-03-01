using UnityEngine;
using System.Collections;

public class LiveLoseScript : MonoBehaviour {
	//Reference to the game master
	private LivesScript GM;

	void Start(){
		//find the GM
		GameObject Temp;
		Temp = GameObject.Find ("_GM");
		GM = Temp.GetComponent<LivesScript> ();
	}
	//on collide with enemy
	void OnCollisionEnter2D(Collision2D collider){
		Debug.Log ("Collide");
		if (collider.gameObject.tag == "Enemy") {
			Debug.Log ("Enemy");
			Destroy(collider.gameObject);
			GM.TakeALife();
		}
	}
}
