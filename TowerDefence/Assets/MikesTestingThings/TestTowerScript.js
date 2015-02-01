#pragma strict

public var TowerAmmo:GameObject;

function Start () {
Shoot();
}

function Update () {

}

function Shoot(){
 Debug.Log("Shot");
 Instantiate(TowerAmmo, Vector3(4,1,0), Quaternion.identity);
 }