using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	#region Variables
	//health related variables
	public int dmgamt = 10;
	public int startHealth = 0;
	public int maxHealth = 50;
	public int health;
	public bool Dead;
	public Slider healthBar;
	public EnemyUI uiScript;
	public EnemyUIDirectControl uiControl;
	
	//firing variables - not needed
//	public float initFireRate = 1f;
//	public float fireRate;
//	public float raycastDist = 100;
//	RaycastHit hit;
//	public GameObject shotHit;
//	HateGun gun;
	#endregion
	
	#region Start
	//initiate once object is ready
	void Start()
	{
		//fireRate = initFireRate;
		health = startHealth;
		uiScript = gameObject.GetComponent<EnemyUI>();
		//healthBar = uiScript.healthSlider;
		healthBar.value = startHealth;
		healthBar.maxValue = maxHealth;
		//gun = gameObject.GetComponentInChildren<HateGun>();
		uiControl = uiScript.uiScript;
	}
	#endregion
	

	#region Update
	// Update is called once per frame
	void Update()
	{
		//destroy the object once it dies
		if (Dead)
		{
			Debug.Log("time to die");
			Destroy (gameObject);
		}
	}
	#endregion

	//UNNEEDED - controlled by EnemyTrigger and HateGun
	#region OnTriggerStay
//	void OnTriggerStay (Collider col)
//	{
//		//when the player is in range, track them and shoot them
//		if (col.tag == "Player")
//		{
//			transform.LookAt (col.transform);
//			gun.isFiring = true;
//			//PlayerHealth plhth = col.GetComponent<PlayerHealth>();
//
//			//use raycast to shoot
////			if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
////			{
////				//cause enemy to take damage
////				if (hit.collider.tag == "Player")
////				{
////					Instantiate (shotHit, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
////					plhth.TakeDmg(dmgamt);
////					Debug.Log ("Hit Player!");
////					
////				}
////				else
////				{
////					Instantiate (shotHit, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
////				}
////			}
//
//
////			fireRate -= Time.deltaTime;
////			if (fireRate < 0)
////			{
////				plhth.TakeDmg(dmgamt);
////				fireRate = initFireRate;
////			}
//		}
//	}
	#endregion

	//unnecessary - controlled by EnemyTrigger
	#region OnTriggerExit
//	void OnTriggerExit(Collider col)
//	{
//		gun.isFiring = false;
//	}
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
