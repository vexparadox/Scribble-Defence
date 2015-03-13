using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementEnemy : MonoBehaviour {
	
	private int nextWaypointIndex = 0;
	public float Speed = 1f;
	public List<Transform> Ways = new List<Transform>();
	public Transform[] Waypoints = new Transform[9];
	//get the Lives GM
	private LivesScript GMLives;
	//get the Spawn GM
	private GameObject GMSpawn;
	// Use this for initialization
	void Start()
	{

		//find the GM
		GameObject Temp;
		Temp = GameObject.Find ("_GM");
		GMLives = Temp.GetComponent<LivesScript> ();
		GMSpawn = Temp;

		//find the way points, no matter how many there are
		for (int i = 0; i < 100; i++) { // loop to an arbitrarily high number
			GameObject tempWay = GameObject.Find ("way" + i); // attempt to find a way point with the loop number
			if (tempWay != null) {
				Ways.Add (tempWay.transform); // if it's found, add it to the list
			} else {
				break; //else stop the loop, you've found all the way points
			}
		}
		for (int i = 0; i < Waypoints.Length; i++) {
			Waypoints[i] = GameObject.Find("way"+i).transform;
		}

	}

	//every frame
	void Update()
	{
		//calculate the distance between current position
		//and the target waypoint
		if (Vector2.Distance(transform.position, Waypoints[nextWaypointIndex].position) < 0.01f) {
			//is this waypoint the last one?
			if (nextWaypointIndex+1 == Waypoints.Length)
			{
				Destroy(gameObject); //remove the object
				GMLives.TakeALife();//take a life away
				GMSpawn.SendMessage("enemyDead"); //mark the enemy as dead in the EnemySpawnScript
				transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypointIndex].position, Time.deltaTime * Speed);
			} else
			{
				//our enemy will go to the next waypoint
				if (nextWaypointIndex != Waypoints.Length-1) {
					nextWaypointIndex++;
				}
			}
		}
		//enemy is moved towards the next waypoint
		transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypointIndex].position, Time.deltaTime * Speed);
	}
}
