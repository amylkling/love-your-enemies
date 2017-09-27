using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Turret : MonoBehaviour {

	#region Variables
	//health related variables
	public int dmgamt = 10;
	public int startHealth = 0;
	public int maxHealth = 50;
	public int health;
	public bool Dead;
	public Slider healthBar;

	//firing variables
	public float initFireRate = 1f;
	public float fireRate;
	#endregion

	#region Awake
	//initiate once object is ready
	void Awake()
	{
		fireRate = initFireRate;
		health = startHealth;
		healthBar.value = startHealth;
		healthBar.maxValue = maxHealth;
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update()
	{
		//destroy the object once it dies
		if (Dead)
		{
			Destroy (gameObject);
		}
	}
	#endregion

	#region OnTriggerStay
	void OnTriggerStay (Collider col)
	{
		//when the player is in range, track them and shoot them
		if (col.tag == "Player")
		{
			transform.LookAt (col.transform);
			PlayerHealth plhth = col.GetComponent<PlayerHealth>();
			fireRate -= Time.deltaTime;
			if (fireRate < 0)
			{
				plhth.TakeDmg(dmgamt);
				fireRate = initFireRate;
			}
		}
	}
	#endregion

	#region TakeDamage
	//track the amount of damage taken by this object
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
	//do things once the object is dead
	void Death()
	{
		Dead = true;
	}
	#endregion
}
