#pragma strict

private var health : HealthScript;
public var visualHealth : UnityEngine.UI.Image;
private var currentXValue : float;
public var healthBar : GameObject;
private var hit : RaycastHit2D;
private var isEnemy: boolean = false;
private var healthAmount : float;
public var towerUp : GameObject;
public var towerText : Text;
public var buttonText : Text;
public var damageText : Text;
private var tower : TowerScript;
private var isTower : boolean = false;
private var x : int = 0;
private var y : float;
private var z : int =0;
private var w :int = 0;

private final var MAX_LEVEL :int = 5;

function Start () {
    healthBar.gameObject.SetActive(false);
    towerUp.gameObject.SetActive(false);
}

function Update () {
	Select();
	if(isEnemy){
		updateHealthBar();
	}
}

function Select(){			// this function selects the clicked target
	if (Input.GetMouseButtonDown(0)){
	
		hit = Physics2D.Raycast(Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0);
 
		 if(hit.collider != null){
			if(hit.transform.gameObject.tag == "Enemy"){ //if the clicked target is enemy
				healthBar.gameObject.SetActive(true);		//it shows the health bar
				health = hit.transform.gameObject.GetComponent(HealthScript);	//gets the clicked enemy 
				updateHealthBar();
				isEnemy = true;
				isTower = false;
				//Debug.Log("Enemy");
				towerUp.gameObject.SetActive(false);
			}
			else if(hit.transform.gameObject.tag == "Tower"){		// if a tower is selected
				healthBar.gameObject.SetActive(false);
				tower = hit.transform.gameObject.GetComponent(TowerScript);	//gets the selected tower
				//Debug.Log("Tower");
				isTower = true;
				isEnemy = false;
				x = tower.towerLevel;	// x, y and z are the variables to print those values on the upgrade menu
				y = tower.attackDamage;
				z = tower.upgradeCost;
				w = tower.towerDamageInc;
				TowerUpgradeUI();
				towerUp.gameObject.SetActive(true);
			}
			else if(hit.transform.gameObject.tag == "Delete" || hit.transform.gameObject.tag == "Button" ) {
			
				var gm = GameObject.FindGameObjectWithTag("GM");
				var currency : CurrencyScript = gm.GetComponent(CurrencyScript);
				
				if(hit.transform.gameObject.tag == "Delete"){
				
					currency.CurrentCurrency += currency.TowerCost[tower.ID];
					currency.UpdateTextCookiesUI();
					Destroy(tower.gameObject);
					
				}
				else if(hit.transform.gameObject.tag == "Button"){	//if the button on the upgrade menu is clicked, this function is called
					
					x = tower.towerLevel;
					y = tower.attackDamage;
					z = tower.upgradeCost*tower.towerLevel;//tower cost*tower level
					w = tower.towerDamageInc;
					//update the interface numbers
					//max level of 5
					if(x != MAX_LEVEL){
						//can you afford it?
						if(currency.CurrentCurrency >= z){
						isEnemy = false;
						tower.towerLevel++;			//increases the tower level						
						tower.attackDamage += w;	//increases the tower damage

						
						currency.CurrentCurrency -= z;
						currency.UpdateTextCookiesUI(); // updates current currency
						
						//update the interface numbers after any changes
						x = tower.towerLevel;
						y = tower.attackDamage;
						z = tower.upgradeCost*tower.towerLevel;//tower cost*tower level

						TowerUpgradeUI();
						towerUp.gameObject.SetActive(true);		//shows the updated menu
						//Debug.Log("level" + tower.towerLevel);
						//Debug.Log("damage" + y);
						}
					}
				}
				} else{
				//if it hits something in the UI but still registers a hit
					towerUp.gameObject.SetActive(false);
					healthBar.gameObject.SetActive(false);
				}
			}
			else{
				Debug.Log("No");		//if the user click in neither a tower or a enemy
			    isEnemy = false;
			    isTower = false;		// the upgrade interface and the health bar are hidden
			    healthBar.gameObject.SetActive(false);
			    towerUp.gameObject.SetActive(false);
			}
		
	}
}

	

public function TowerUpgradeUI(){		// refreshes the interface for the tower upgrade
	if(tower.isPlaced){
		//check for max level
		if(tower.towerLevel == MAX_LEVEL){
			towerText.text = "Max Level "+MAX_LEVEL.ToString();
			buttonText.text = "No Upgrades" ;			//shows the upgrade cost

		}else{
			towerText.text = "Tower Level: " + tower.towerLevel.ToString();		//shows the current level of the tower
				buttonText.text = "Upgrade +" + w + " (" + z.ToString() + " cookies)" ;			//shows the upgrade cost

		}
		damageText.text = "Damage: " + y.ToString();						//shows the current damage the tower inflicts
	}
}

	
function updateHealthBar(){			//updates the health bar if the life is bigger than 0
	if(health.currentHealth > 0){
		HealthBar();
	}
	if(health.isDead){				//hides health bar if the target is dead
		healthBar.gameObject.SetActive(false);
	}
}

public function HealthBar(){

	healthAmount = (health.currentHealth)/(health.maxHealth);
    visualHealth.fillAmount = healthAmount;		// update the health bar position

    
	 if (health.currentHealth > health.maxHealth / 2){	//based on life proportions from Map() function, generates colors for the life bar
	 	
	 	visualHealth.color = new Color32(Map(health.currentHealth,health.maxHealth/2,health.maxHealth,255,0),255,0,255);
	 
	 }else{
	 	visualHealth.color = new Color32(255,Map(health.currentHealth, 0, health.maxHealth / 2, 0, 255),0,255);
	 }
}



/// <param name="x">The value to evaluate</param>
/// <param name="in_min">The minimum value of the evaluated variable</param>
/// <param name="in_max">The maximum value of the evaluated variable</param>
/// <param name="out_min">The minum number we want to map to</param>
/// <param name="out_max">The maximum number we want to map to</param>
/// <returns></returns>
function Map(x : float, in_min : float , in_max: float ,out_min : float ,out_max : float ){ //maps the life proportions 
	return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
}

