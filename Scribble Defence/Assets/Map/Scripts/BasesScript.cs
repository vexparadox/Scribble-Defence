using UnityEngine;
using System.Collections;

public class BasesScript : MonoBehaviour {
	public bool[] BaseStatus;
	private int numBases = 0;

	void Start(){
		//find how many bases there are
		for (int i = 0; i < 200; i++) { // loop to an arbitrarily high number
			GameObject tempBase = GameObject.Find("base" + (i+1)); // attempt to find a way point with the loop number
			if (tempBase != null && tempBase.gameObject.tag == "Base") {
				numBases++; // if it's found, add it to the list
			} else {
				break; //else stop the loop, you've found all the way points
			}
		}

		BaseStatus = new bool[numBases];
		//start them all off as false
		for (int i = 0; i < BaseStatus.Length; i++) {
			BaseStatus[i] = false;
				}
	}

	public bool Basefull(int baseID){
		//return if it can be placed
		if (BaseStatus [baseID]) {
			return false;
			}
		return true;
	}

	public void Basefill(int baseID){
		//set to true when filled
		BaseStatus [baseID] = true;
	}

	public void Baseempty(int baseID){
		BaseStatus[baseID] = false;
	}
}
