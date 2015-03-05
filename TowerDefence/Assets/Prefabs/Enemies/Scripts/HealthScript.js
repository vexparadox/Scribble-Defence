#pragma strict

	public var maxHealth:int; //holds the maximum health it can have
	private var health:int; // holds current health, this changes throughout
	
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
	health = maxHealth;
	//find the game master
	_GM = GameObject.Find("_GM");
}

function Update () {
//if he's dead, kill him
		if (health < 1) {
			Destroy(gameObject);
			_GM.SendMessage("deadCash", enemyID);
			_GM.SendMessage("enemyDead");
		}
}

function OnCollisionEnter2D(collider: Collision2D)
	{
		if (collider.gameObject.tag == "Bullet") //if hit by a bullet
		{
			Destroy(collider.gameObject); // destroy the bullet on contact
			if (health > 1)
			{	
				var ammo : AmmoScript; //get the ammoScript attached to the offending bullet
				ammo = collider.gameObject.GetComponent(AmmoScript); // get the component
				health -= ammo.attackDamage; //take the set amount of damage away from the health
			}
		}
		
	}