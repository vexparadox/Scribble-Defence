using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour 
{	
	//click drag variables
	public GameObject grid; // holds the gameObject of the grid, this activates and deactivates on mouseup/down
	private Vector3 startPoint; // holds the original vector of the UI tower
	private Vector3 screenPoint; // holds the tower(dragged) vector relative to the screen
	private Vector3 endPosition; // holds the end position of the tower, this is where it will be places
	private Vector3 curPosition; // holds the current world position of the mouse
	public GameObject toSpawn; // this is the prefab which will spawn on mouseUp
	private bool snapped = false; // checks whether the tower is in a place ready to go

	//snap to base variables
	private float leastDistance;
	private int closerBase;
	private Transform basePosition;
	//holds the position and status of that base
	public Transform[] bases = new Transform[20];
	public int[] baseStatus = new int[20];


	void Start(){
		//find all the bases on the map
		for (int i=0; i<bases.Length; i++) {
			bases[i] = GameObject.Find("base"+(i+1)).transform;
		}
		//initialise the baseStatus with 0, this means there's no tower there
		for (int i=0; i<bases.Length; i++) {
			baseStatus[i] = 0;
		}
	}

	void OnMouseDown()
	{
		grid.renderer.enabled = true;
		//get the screen relative point and make note of the start position of the tower
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		//get the screen relative point and make note of the start position of the tower
		startPoint = gameObject.transform.position;
	}
	
	void OnMouseDrag()
	{	

		//get the current screen position mouse
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//use the above the current position of the mouse, in world coordinates
		curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);

		//find the closest base to the mouse/tower(dragged)
		leastDistance = Vector2.Distance(bases[0].transform.position,curPosition);
		closerBase = 0;
		for(int i=0;i<bases.Length;i++){
			//to take the shortest distance to the base of the tower
			if( Vector2.Distance(bases[i].transform.position,curPosition) < leastDistance){
				leastDistance = Vector2.Distance(bases[i].transform.position,curPosition);
				closerBase = i;
			}
			
		}

		//if the distance to the closet base is less than 2 and it's not already ocuppied
		//else if will just follow the mouse
		if (Vector2.Distance (transform.position, bases[closerBase].position) < 1 && baseStatus[closerBase] != 1) {
			transform.position = bases [closerBase].position; // move the tower(dragged) onto the base
			endPosition = bases [closerBase].position; // set an end position to instantiate an object onto
			snapped = true; // set the snapped to true
				} else {
			transform.position = curPosition;
			snapped = false;
				}
	}

	void OnMouseUp(){
		//sort out some booleans
		grid.renderer.enabled = false; //disable the grid showing
		transform.position = startPoint; // ping the tower back to it's UI start position
		//make sure it's actually on a base before placing
		if (snapped) {
			baseStatus [closerBase] = 1; //mark the base as occupied
			Instantiate (toSpawn, endPosition, Quaternion.identity); //create an object at that point
			snapped = false; // flip the snapped variable
			}
	}
	
}