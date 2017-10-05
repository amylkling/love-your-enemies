using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//controls the player's gun

public class LoveGun : MonoBehaviour {

	#region Variables
	//variables needed to shoot the gun
	public int ammo = 100;					//current amount of ammo
	public int ammoMax = 100;				//maximum amount of ammo
	public int damageAmount = 10;			//amount of damage done by each shot
	public float raycastDist = 100.0f;		//maximum range of the gun

	//sound variables
	public AudioSource gun;					//audiosource to feed sounds to
	public AudioClip gunShot;				//the sound played when firing a shot
	public AudioClip dryFire;				//the sound played when trying to fire without ammo

	//variable for effects
	public GameObject shotHit;				//the particle effect prefab for when a shot hits something
	public GameObject gunEffect;			//the particle effect prefab for firing the gun
	public GameObject effect;				//the created gunEffect object

	//GUI variable
	public Text ammoGUI;					//text displaying amount of ammo

	//enemy script
	public Enemy enemy;						//reference to the enemy's script
	#endregion

	#region Start()
	//initialize GUI
	void Start()
	{
		UpdateGUI();
		gun = gameObject.GetComponent<AudioSource>();
	}
	#endregion
	
	#region Update()
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			//shoot as long as there is ammo
			if (ammo > 0)
			{
				//determine if the "shot" hit anything
				if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
				{
					//cause enemy to take damage
					if (hit.collider.tag == "Enemy2")
					{
						Instantiate (shotHit, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
						effect = Instantiate (gunEffect, gameObject.transform.position, Quaternion.identity) as GameObject; 
						effect.transform.SetParent (gameObject.transform);
						enemy = hit.collider.GetComponent<Enemy>();
						enemy.TakeDmg(damageAmount);
						Debug.Log ("Hit Enemy!");
						gun.clip = gunShot;
						gun.Play ();

					}
					else
					{
						Instantiate (shotHit, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
						effect = Instantiate (gunEffect, gameObject.transform.position, Quaternion.identity) as GameObject; 
						effect.transform.SetParent (gameObject.transform);
						gun.clip = gunShot;
						gun.Play ();
					}
				}
				else
				{
					//play a sound if the shot misses
					gun.clip = gunShot;
					gun.Play ();
					effect = Instantiate (gunEffect, gameObject.transform.position, Quaternion.identity) as GameObject;
					effect.transform.SetParent (gameObject.transform);
				}
				 

				//decrease ammo
				ammo--;
			}
			else
			{
				//play a different sound when out of ammo
				gun.clip = dryFire;
				gun.Play ();
			}
		}

		//enforce max ammo limit
		if (ammo > ammoMax)
		{
			ammo = ammoMax;
		}

		//update GUI to reflect changes
		UpdateGUI ();
		
	}
	#endregion

	#region Update GUI()
	//set the GUI to show the current amount of ammo
	void UpdateGUI()
	{
		ammoGUI.text = "Ammo: " + ammo.ToString("00");
	}
	#endregion
}
