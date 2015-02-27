using UnityEngine;
using System.Collections;

public class torres : MonoBehaviour {
	
	public Transform[] bases = new Transform[20];
	public Vector2 towerPosition;
	public float leastDistance;
	public int closerBase;
	public Vector2 positionTorre;
	public Transform basePosition;
	public int[] baseStatus = new int[20];
	
	// Use this for initialization
	void Start () {
		
		positionTorre = gameObject.transform.position;
		
		for (int i=0; i<20; i++) {
			bases[i] = GameObject.Find("base"+(i+1)).transform;
		}
		
		for (int i=0; i<20; i++) {
			baseStatus[i] = 0;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		towerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		leastDistance = Vector2.Distance(bases[0].transform.position,towerPosition);
		closerBase = 0;
		for(int i=0;i<20;i++){
			//pra pegar a menor distancia pra a base da torre
			if( Vector2.Distance(bases[i].transform.position,towerPosition) < leastDistance){
				leastDistance = Vector2.Distance(bases[i].transform.position,towerPosition);
				closerBase = i;
			}
			
		}
		
		basePosition.position = bases[closerBase].position;
		if (Input.GetMouseButtonDown (0) && Vector2.Distance (towerPosition, bases [closerBase].position) < 1 && baseStatus [closerBase] == 0) {
			//gameObject.transform.position = bases[closerBase].position;
			gameObject.transform.position = bases [closerBase].position;
			baseStatus [closerBase] = 1;
		} else if (Input.GetMouseButtonDown (0) && baseStatus [closerBase] == 1) {
			gameObject.transform.position = bases [closerBase+1].position;
			baseStatus[closerBase+1] = 1;
		}
		
		
		
	}
}