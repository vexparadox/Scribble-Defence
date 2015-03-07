using UnityEngine;
using System.Collections;

public class AmmoDestroyer : MonoBehaviour {

	void OnCollisionEnter2D(Collider2D other){
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb") {
			Destroy(other.gameObject);
				}
	}
}
