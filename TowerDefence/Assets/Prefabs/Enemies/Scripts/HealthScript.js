#pragma strict

	public var maxHealth:int; //holds the maximum health it can have
	private var health:int;
	public var dmgInterval:int; //holds the wait between taking damage
	private var cd = false;

function Start () {
		cd = false;
		health = maxHealth;
}

function Update () {
//if he's dead, kill him
		if (health < 1) {
			Destroy(gameObject);
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