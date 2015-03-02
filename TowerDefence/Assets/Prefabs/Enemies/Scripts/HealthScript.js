#pragma strict

	public var maxHealth:int; //holds the maximum health it can have
	private var health:int; // holds current health, this changes throughout
	public var dmgInterval:float; //holds the wait between taking damage
	private var cd = false; //whether the cool down is active or not
	
	
	//holds the enemy's ID
	/*
	0 = grunt
	1 = tank
	2 = speedy
	3 = boss
	*/
	public var enemyID: int;
	
	//Reference to the game master
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
			_GM.SendMessage("deadCash", enemyID);
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