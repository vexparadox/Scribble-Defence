using UnityEngine;
using System.Collections;

public class GridMovement : MonoBehaviour {
	public float speed = 10f;
	private Vector2 target;
	// Use this for initialization
	void Start () {
		target = transform.position;
		
	}
	// Update is called once per frame
	void Update () {
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.x = transform.position.x;
		target.y = transform.position.y;
		transform.position = new Vector2(target.x, target.y);
	}
}
