#pragma strict
// Draws 2 toggle controls, one with a text, the other with an image.
	
	public var toggleVSync : boolean = true;
	public var texture : Texture;

	function OnGUI () {
		toggleVSync = GUI.Toggle(Rect((Screen.width/2)-100, 40, 100, 30), toggleVSync, texture);
	}
	
	function Update(){
		if(toggleVSync){
			QualitySettings.vSyncCount = 1;
		} else{
			QualitySettings.vSyncCount = 0;
		}
	}