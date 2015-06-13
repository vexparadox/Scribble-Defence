using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int startingHealth, //how much health they have 
	worth, // how much the enenmy is worth
	enemyID;
	public float currentHealth, //this is the current health of the enemy
	maxHealth; // this holds the maximum health of the enemy during the wave

	private int waveModifier = 15, // wave modifier allows the enemies to grow stronger after every wave
	aoeRange; //the area of effect range
	private bool isDead = false; //is the enemy dead?

	private GameObject _GM; // the game master game object
	private CurrencyScript currencyScript; // the currency script

	// Use this for initialization
	void Start () {
		_GM = GameObject.Find ("_GM");
		currencyScript = _GM.GetComponent<CurrencyScript>();
		//currentWaveNumber = _GM.GetComponent(EnemySpawnScript).currentWave; //get the wave number
		maxHealth = startingHealth + (waveModifier); //initiate health and add the wave modifier
		currentHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		//if he's dead, kill him
		if (currentHealth <= 0) {
			isDead = true;
			Destroy(gameObject);	
			currencyScript.deadCash(worth); // call the dead cash in
			_GM.SendMessage("enemyDead");
		}
	}

	//take damage
	void updateHealth(float damage){
		currentHealth -= damage;
	}

	//handle bullet hits
	void OnCollisionEnter2D(Collision2D collider){
		AmmoProjectile ammo;
		ammo = collider.gameObject.GetComponent<AmmoProjectile>();
		float attackDamage = ammo.attackDmg;
		if (collider.gameObject.tag == "Bullet") //if hit by a bullet
		{
			Destroy(collider.gameObject); // destroy the bullet on contact
			if (currentHealth > 0)
			{	
				updateHealth(attackDamage); //take the set amount of damage away from the health
			}
		}
		else if(collider.gameObject.tag == "Bomb") // if hit by a bomb/AOE bullet
		{
			
			if (currentHealth > 0 )
			{	
				int aoeRange = ammo.aoe;
				EnemyHealth damagedEnemies;			

				GameObject[] EnemyFinder= GameObject.FindGameObjectsWithTag("Enemy");
				
				for (int i= 0 ; i<EnemyFinder.Length ; i++){
					Vector2 Enemy= EnemyFinder[i].transform.position;
					float Distance= Vector2.Distance(Enemy, collider.transform.position); 	
					if(Distance<=aoeRange){
						damagedEnemies = EnemyFinder[i].gameObject.GetComponent<EnemyHealth>(); //find the health of the enemy
						damagedEnemies.updateHealth(attackDamage/2); //do an AOE damage of half of the attack
					}
				}
			}
			
			Destroy(collider.gameObject); // destroy the bullet on contact
			
		}

	}
}
