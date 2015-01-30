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
	
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		startPoint = gameObject.transform.position;
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;
		endPosition = curPosition;
	}

	void OnMouseUp(){
		gameObject.transform.position = startPoint;
		Instantiate (toSpawn, endPosition, Quaternion.identity);

	}
	
}