#pragma strict
	public var maxHealth:int; //holds the maximum health it can have
	public var health:int; // holds current health, this changes throughout
	private var aoe:int; //area of effect	
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

function updateHealth(dmg : int){
	health -= dmg;
}

function OnCollisionEnter2D(collider: Collision2D)
	{
		var ammo : AmmoScript; //get the ammoScript attached to the offending bullet
		ammo = collider.gameObject.GetComponent(AmmoScript);// get the component
		
		if (collider.gameObject.tag == "Bullet") //if hit by a bullet
		{
			Destroy(collider.gameObject); // destroy the bullet on contact
			if (health > 1)
			{	

				updateHealth(ammo.attackDamage); //take the set amount of damage away from the health
			}
		}
		else if(collider.gameObject.tag == "Bomb") // if hit by a bomb
		{

			if (health > 1)
			{	
				aoe = ammo.aoeRange;
			
				var damagedEnemies : HealthScript;			
				
				var EnemyFinder = GameObject.FindGameObjectsWithTag("Enemy");
 
				for (var i = 0 ; i<EnemyFinder.length ; i++){
  					var Enemy = EnemyFinder[i].transform.position;
 					var Distance= Vector2.Distance(Enemy, collider.transform.position); 	
 					   	if(Distance<=aoe){
  						 damagedEnemies = EnemyFinder[i].gameObject.GetComponent(HealthScript);
  						 damagedEnemies.updateHealth(ammo.attackDamage);
    				}
    			}
			}
			
			Destroy(collider.gameObject); // destroy the bullet on contact
		}
		
	}