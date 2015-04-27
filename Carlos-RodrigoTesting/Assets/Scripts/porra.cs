using UnityEngine;
using System.Collections;

public class porra : MonoBehaviour {

	public Transform[] waypoints = new Transform[5];
	public float speed = 10;
	public int currentWay;
	public bool loop = false;
	public float distance = 0.5f;
	public Vector3 velocity;
	// Use this for initialization
	void Start () {
		waypoints[0] = GameObject.Find("way1").transform;
		waypoints[1] = GameObject.Find("way2").transform;
		waypoints[2] = GameObject.Find("way3").transform;
		waypoints[3] = GameObject.Find("way4").transform;
		waypoints[4] = GameObject.Find("way5").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(currentWay < waypoints.Length) { 
			Vector3 target = waypoints[currentWay].position; 
			Vector3 moveDirection = target - transform.position;
			
			velocity = rigidbody2D.velocity; 

			if(moveDirection.magnitude < distance){
				currentWay++; 
			}else{ 
				velocity = moveDirection.normalized * speed; 
			} 
		}
		
		else{ 
			if(loop){ 
				currentWay = 0; 
			} else { 
				velocity = Vector3.zero; 
			} 
		} 
		rigidbody2D.velocity = velocity;
		transform.Translate(velocity.x,velocity.y,0);
	}
}
