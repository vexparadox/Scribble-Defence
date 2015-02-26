#pragma strict
var _GM:GameObject;

function Start () {
_GM = GameObject.Find("_GM");
}

function Update () {
//dai();
}

function dai(){
_GM.SendMessage("deadGrunt");
}
