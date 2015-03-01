#pragma strict

	public var maxHealth:int; //holds the maximum health it can have
	private var health:int;
	public var dmgInterval:float; //holds the wait between taking damage
	private var cd = false;
	public var enemyID: int;
	
	//currency addition
	//public var nameOfEnemy:string;
	private var _GM:GameObject;

function Start () {
		cd = false;
		health = maxHealth;
		//find the game master
		_GM = GameObject.Find("_GM");
}

function Update () {
//if he's dead, kill him
		if (health < 1) {
			Destroy(gameObject);
			_GM.SendMessage("enemyDead", enemyID);
		}
}

function OnCollisionEnter2D(collider: Collision2D)
	{
		if (collider.gameObject.tag == "Bullet") //if hit by a bullet
		{
			Destroy(collider.gameObject); // destroy the bullet on contact
			if (!cd && health > 1)
			{
				health -= 20; //take damage
				cd = true; //cool down, can't take damage
				yield WaitForSeconds(dmgInterval); //Waits a while before we are ab1le to take dmg again
				cd = false; //can now take damage again
			}
		}
		
	}