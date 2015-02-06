using UnityEngine;
using System.Collections;

public class MovementEnemy : MonoBehaviour {

		int nextWaypointIndex = 0;
		
		public float Speed = 1f;
		public GameObject enemy;
		
		public Transform[] Waypoints = new Transform[15];
		
		//public Transform way1,way2,way3,way4,way5;
		
		// Use this for initialization
		void Start()
		{
			Waypoints[0] = GameObject.Find("way1").transform;
			Waypoints[1] = GameObject.Find("way2").transform;
			Waypoints[2] = GameObject.Find("way3").transform;
			Waypoints[3] = GameObject.Find("way4").transform;
			Waypoints[4] = GameObject.Find("way5").transform;
			Waypoints[5] = GameObject.Find("way6").transform;
			Waypoints[6] = GameObject.Find("way7").transform;
			Waypoints[7] = GameObject.Find("way8").transform;
			Waypoints[8] = GameObject.Find("way9").transform;
			Waypoints[9] = GameObject.Find("way10").transform;
			Waypoints[10] = GameObject.Find("way11").transform;
			Waypoints[11] = GameObject.Find("way12").transform;
			Waypoints[12] = GameObject.Find("way13").transform;
			Waypoints[13] = GameObject.Find("way14").transform;
			Waypoints[14] = GameObject.Find("way15").transform;
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
