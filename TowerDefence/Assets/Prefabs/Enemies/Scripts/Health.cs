public int maxHealth;
private int health;
public float dmgInterval;
private bool cd;

public int Health
{
	get { return health; }
	set
	{
		health = value;
		//healthBarController();
	}
}

void Start () {
	cd = false;
	health = maxHealth;
	
}	

IEnumerator CoolDownDmg()
{
	cd = true; 
	yield return new WaitForSeconds(dmgInterval); //Waits a while before we are ab1le to take dmg again
	cd = false;
}

void OnTriggerEnter2D(Collider2D other)
{
	if (other.gameObject.name == "Enemy") //Used for simulating taking damage
	{
		//Debug.Log("encostou");
		//Debug.Log("health =  " + health);
		//Debug.Log ("green x= " + visualHealth.transform.position.x);
		//Debug.Log ("green y= " + visualHealth.transform.position.y);
		//Debug.Log ("white x= " + test.transform.position.x);
		//Debug.Log ("white y= " + test.transform.position.y);
		//Debug.Log ("currentXValue = " + currentXValue);
		if (!cd && health > 1)
		{
			StartCoroutine(CoolDownDmg()); //Makes sure that we can't take damage right away
			Health -= 20; //Uses the Health Property to so that we recolor and rescale the health when we 	 //change it
		}
	}
	
}