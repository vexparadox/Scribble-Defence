using UnityEngine;
using System.Collections;

public class MovementEnemy : MonoBehaviour {

		int nextWaypointIndex = 0;
		
		public float Speed = 1f;
		public GameObject enemy;
		
		public Transform[] Waypoints = new Transform[9];
		
		//public Transform way1,way2,way3,way4,way5;
		
		// Use this for initialization
		void Start()
		{
		for (int i = 0; i < Waypoints.Length; i++) {
			Waypoints[i] = GameObject.Find("way"+(i+1)).transform;
				}
		}
		// Update is called once per frame
		void Update()
		{
			//calculate the distance between current position
			//and the target waypoint
			
			if (Vector2.Distance(transform.position,
			                     Waypoints[nextWaypointIndex].position) < 0.01f)
			{
				//is this waypoint the last one?
				if (nextWaypointIndex == Waypoints.Length)
				{
					//RemoveAndDestroy();
					//GameManager.Instance.Lives--;
					transform.position = Vector2.MoveTowards(transform.position,
					                                         Waypoints[nextWaypointIndex].position,
					                                         Time.deltaTime * Speed);
				Destroy (enemy);
				}
				else
				{
					//our enemy will go to the next waypoint
					nextWaypointIndex++;
					Debug.Log(nextWaypointIndex);
					//our simple AI, enemy is looking at the next waypoint
					transform.LookAt(Waypoints[nextWaypointIndex].position,
					                 -Vector3.forward);
					//only in the z axis
					transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
					Debug.Log(nextWaypointIndex);


				}
			}
			//enemy is moved towards the next waypoint
			transform.position = Vector2.MoveTowards(transform.position,
			                                         Waypoints[nextWaypointIndex].position,
			                                         Time.deltaTime * Speed);
		}
		
	}
