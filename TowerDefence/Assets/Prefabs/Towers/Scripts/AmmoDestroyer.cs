using UnityEngine;
using System.Collections;

public class AmmoDestroyer : MonoBehaviour {

	void OnCollision2D(Collider2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy(other);
				}
	}
}
