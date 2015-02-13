#pragma strict

function Start () {

}

function Update () {
beginCountdown();
}

function beginCountdown(){
yield WaitForSeconds(2);
Destroy(gameObject);
}