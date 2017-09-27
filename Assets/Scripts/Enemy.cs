using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//controls the nemy's stats and state

public class Enemy : MonoBehaviour {

	#region Variables
	//health related variables
	public int startHealth = 0;					//initial health value
	public int maxHealth = 50;					//maximum health value
	public int health;							//current health value
	public bool Dead;							//is the enemy dead?
	public Slider healthBar;					//the healthbar UI
	public EnemyUI uiScript;					//the UI script for this enemy
	public EnemyUIDirectControl uiControl;		//the UI control script for this enemy
	#endregion
	
	#region Start
	//initiate once object is ready
	void Start()
	{
		health = startHealth;
		uiScript = gameObject.GetComponent<EnemyUI>();
		//healthBar = uiScript.healthSlider;
		healthBar.value = startHealth;
		healthBar.maxValue = maxHealth;
		uiControl = uiScript.uiScript;
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update()
	{
		//destroy the enemy once it dies
		if (Dead)
		{
			Debug.Log("time to die");
			Destroy (gameObject);
		}
	}
	#endregion
	
	#region TakeDamage
	//track the amount of damage taken by this enemy
	public void TakeDmg(int amount)
	{
		health += amount;
		healthBar.value = health;
		Debug.Log ("Damn you!");
		if (health >= maxHealth && !Dead)
		{
			Death();
		}
	}
	#endregion
	
	#region Death
	//set the enemy's state to Dead
	void Death()
	{
		Dead = true;
	}
	#endregion
}
