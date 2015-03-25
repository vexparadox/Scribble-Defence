using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject rangeCircle; //Holds the range circle

	//snap to base variables
	private float leastDistance;
	private int closerBase;
	private Transform basePosition;
	//holds the position and status of that base
	public List<Transform> bases = new List<Transform>();
	//public Transform[] bases = new Transform[20];
	//used to identify the tower you've picked up
	//tower 1 = 0, tower 2 = 1 etc..
	public int TowerID;

	//Reference to the game master
	private CurrencyScript CurrencyGM;
	private BasesScript BasesGM;


	void Start(){
		//find all the bases on the map
		for (int i = 0; i < 200; i++) { // loop to an arbitrarily high number
			GameObject tempBase = GameObject.Find("base" + (i+1)); // attempt to find a way point with the loop number
			if (tempBase != null && tempBase.gameObject.tag == "Base") {
				bases.Add(tempBase.transform); // if it's found, add it to the list
			} else {
				break; //else stop the loop, you've found all the way points
			}
		}
		//remove the pesky null things
		for (int k = bases.Count-1; k >= 0; k--) {
			if(bases[k] == null){
				bases.RemoveAt(k);
			}
		}

		//find the GM
		GameObject Temp;
		Temp = GameObject.Find ("_GM");
		BasesGM = Temp.GetComponent<BasesScript> (); // get the bases script
		CurrencyGM = Temp.GetComponent<CurrencyScript> (); // get the currency GM
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
		rangeCircle.transform.position = new Vector3 (curPosition.x, curPosition.y, 0);
		//find the closest base to the mouse/tower(dragged)
		leastDistance = Vector2.Distance(bases[0].transform.position,curPosition);
		closerBase = 0;
		for(int i=0;i<bases.Count;i++){
			//to take the shortest distance to the base of the tower
			if( Vector2.Distance(bases[i].transform.position,curPosition) < leastDistance){
				leastDistance = Vector2.Distance(bases[i].transform.position,curPosition);
				closerBase = i;
			}
			
		}

		//if the distance to the closet base is less than 2 and it's not already ocuppied
		//else if will just follow the mouse
		if (Vector2.Distance (transform.position, bases[closerBase].position) < 1 && BasesGM.Basefull(closerBase)) {
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
		rangeCircle.transform.position = new Vector3 (-20, 0, 0);
		grid.renderer.enabled = false; //disable the grid showing
		transform.position = startPoint; // ping the tower back to it's UI start position
		//make sure it's actually on a base before placing
		if (snapped && CurrencyGM.CanAfford(TowerID)) {
			BasesGM.Basefill(closerBase); // make the base filled
			Instantiate (toSpawn, endPosition, Quaternion.identity); //create an object at that point
			snapped = false; // flip the snapped variable
			}
	}
	
}