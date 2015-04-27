using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public Transform[] waypoints = new Transform[10];
	int currentposition = 0;
	public Vector3 distance;
	public float accelarate = 1.8f;
	// Use this for initialization
	void Start () {
	
		waypoints [0] = GameObject.Find ("waypoint").transform;
		waypoints [1] = GameObject.Find ("waypoint1").transform;
		waypoints [2] = GameObject.Find ("waypoint2").transform;
		waypoints [3] = GameObject.Find ("waypoint3").transform;
		waypoints [4] = GameObject.Find ("waypoint4").transform;
		waypoints [5] = GameObject.Find ("waypoint5").transform;
		waypoints [6] = GameObject.Find ("waypoint6").transform;
		waypoints [7] = GameObject.Find ("waypoint7").transform;
		waypoints [8] = GameObject.Find ("waypoint8").transform;
		waypoints [9] = GameObject.Find ("waypoint9").transform;
		waypoints [10] = GameObject.Find ("last").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(currentposition == 9){
			Destroy(this.gameObject);
		}else{
			walk();
		}
}

	void walk(){

		distance = waypoints[currentposition].position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(distance);
	
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
		float speedElement = Vector3.Dot(distance.normalized, transform.forward);
		float speed = accelarate + speedElement;
		if (distance.magnitude < 0.05) {
			currentposition++;
		}
		transform.Translate(0,0,Time.deltaTime*speed);
	
	}

	/*
	void onTriggerEnter(Collider collider){


		if (collider.tag ==  "waypoint") {
			currentposition++;
		}
	}*/




}