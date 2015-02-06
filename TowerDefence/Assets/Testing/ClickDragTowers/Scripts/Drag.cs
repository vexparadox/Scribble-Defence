using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Drag : MonoBehaviour 
{
	private Vector3 startPoint;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 endPosition;
	public GameObject toSpawn;
	private bool clicked = false;
	public float snapValue = 10;

	void OnMouseDown()
	{
		//get the screen relative point and make note of the start position of the tower
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		startPoint = gameObject.transform.position;
		clicked = true;
		//offset to make the tower drag behind
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		//get the current screen position mouse
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//apply that to the tower being dragged - this makes the tower follow the mouse
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;
	}

	void Update(){

		if (clicked) {
			//snap to grid functions
			float snapInverse = 1/snapValue;
			float x, y;
			//round the values to the snap value
			x = Mathf.Round(transform.position.x * snapInverse)/snapInverse;
			y = Mathf.Round(transform.position.y * snapInverse)/snapInverse;
			transform.position = new Vector2(x, y);
			//get the position of where to apply the new tower
			//MUST BE USED HERE OR WILL GO WHERE THE MOUSE IS, NOT WHERE THE TOWER IS
			endPosition = transform.position;
				}
	}

	void OnMouseUp(){
		//create object
		clicked = false;
		transform.position = startPoint;
		Instantiate (toSpawn, endPosition, Quaternion.identity);

	}
	
}