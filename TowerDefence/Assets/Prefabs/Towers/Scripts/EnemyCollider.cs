using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		
	}
