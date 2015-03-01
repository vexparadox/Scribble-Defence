using UnityEngine;
using System.Collections;

public class MovementEnemy : MonoBehaviour {
	
	private int nextWaypointIndex = 0;
	public float Speed = 1f;
	public Transform[] Waypoints = new Transform[9];
	//get the Lives GM
	private LivesScript GM;
	// Use this for initialization
	void Start()
	{

		//find the GM
		GameObject Temp;
		Temp = GameObject.Find ("_GM");
		GM = Temp.GetComponent<LivesScript> ();

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
			if (nextWaypointIndex+1 == Waypoints.Length)
			{
				Destroy(gameObject); //remove the object
				GM.TakeALife();//take a life away
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
