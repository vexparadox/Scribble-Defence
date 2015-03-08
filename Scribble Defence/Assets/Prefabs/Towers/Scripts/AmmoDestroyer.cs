using UnityEngine;
using System.Collections;

public class AmmoDestroyer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb") {
			Destroy(other.gameObject);
				}
	}
}
