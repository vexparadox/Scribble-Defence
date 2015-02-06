using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Transform path;
	public Vector3 distance;
	public float minimumDistance;
	public float distWaypoint;
	public Quaternion rotacao;
	public Vector3 rot;
	public Vector3 rot2;
	public int child;
	public int child2;
	// Use this for initialization
	void Start () {
		path = GameObject.Find("Waypoints").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		distance = path.position - transform.position;
		//minimumDistance = Vector3.Distance(transform.position, path.position);
		Vector3 movementNormal = Vector3.Normalize(distance);
		distWaypoint = distance.magnitude;
		float targetAngle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;

		if (distWaypoint < 0.4) {
						child = path.childCount;
						if (path.childCount > 0) {
								path = path.GetChild (0);
								child2 = path.childCount;
						}else{
						// Inform level script that a unit has reached the last waypoint
						//					_levelScript.reduceHearts(1);
						Destroy(gameObject);
						return;
			}
		} else {

			//rigidbody2D.AddForce(new Vector2(movementNormal.x, movementNormal.y) * 2);
			transform.Translate(movementNormal.x,movementNormal.y,0);
			//rotacao = Quaternion.LookRotation(distance);
			//rot = rotacao.eulerAngles;
			//rot2 = transform.rotation.eulerAngles;
			//rot2.y = rot.y - 180;
			//transform.Translate (0, 2, 0);

		}

		transform.rotation = Quaternion.Euler(0, 0, targetAngle);
	}
}
