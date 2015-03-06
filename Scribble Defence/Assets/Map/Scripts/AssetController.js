#pragma strict
public var grid:GameObject;

function Start () {
	grid.renderer.enabled = false; //disable the grid from being shown
	Screen.sleepTimeout = SleepTimeout.NeverSleep; // stop screen from sleeping
}