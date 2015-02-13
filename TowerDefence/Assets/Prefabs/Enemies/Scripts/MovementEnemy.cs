using UnityEngine;
using System.Collections;

public class MovementEnemy : MonoBehaviour {
	
	private int nextWaypointIndex = 0;
	public float Speed = 1f;
	public Transform[] Waypoints = new Transform[9];
	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < Waypoints.Length; i++) {
			Waypoints[i] = GameObject.Find("way"+i).transform;
		}
	}
	// Update is called once per fr
	void Update()
	{
		//calculate the distance between current position
		//and the target waypoint
		
		if (Vector2.Distance(transform.position, Waypoints[nextWaypointIndex].position) < 0.01f) {
			//is this waypoint the last one?
			if (nextWaypointIndex == Waypoints.Length)
			{
				//RemoveAndDestroy();
				//GameManager.Instance.Lives--;
				transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypointIndex].position, Time.deltaTime * Speed);
			} else
			{
				//our enemy will go to the next waypoint
				if (nextWaypointIndex != Waypoints.Length-1) {
					nextWaypointIndex++;
				}
				/* REMOVED BECUASE IT WAS ROTATING THE ENEMY TO LOOK AT THE WAYPOINTS
         transform.LookAt(Waypoints[nextWaypointIndex].position, -Vector3.forward);
         transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
         */
			}
		}
		//enemy is moved towards the next waypoint
		transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypointIndex].position, Time.deltaTime * Speed);
	}
}
