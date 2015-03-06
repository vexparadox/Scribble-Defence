#pragma strict

public var playerMoney = 100;

function Start () {

}

function Update () {
}

function deadGrunt(){
playerMoney += 10;
Debug.Log(playerMoney);
}

function deadTank(){
playerMoney += 20;
}

function deadScout(){
playerMoney +=20;
}

function deadBoss(){
playerMoney+=50;
}