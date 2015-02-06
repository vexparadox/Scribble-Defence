using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Bullet") {
			Destroy(collision.gameObject);
		}
	}
}
