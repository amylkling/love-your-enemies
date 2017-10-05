using UnityEngine;
using System.Collections;

//controls the pickups

public class Pickup : MonoBehaviour {

	#region Variables
	//variables for controlling the pickup
	public int ammoUp = 20;			//amount of ammo to give upon pickup
	public int healthUp = 20;		//amount of health to give upon pickup
	float reTimer;					//respawn timer
	public float delay = 5.0f;		//respawn delay
	bool disable = false;			//whether this pickup should disable itself

	//script and object reference variables
	GameObject player;				//the player object
	PlayerHealth pHealth;			//reference to the player health script
	LoveGun gun;					//reference to the lovegun script
	#endregion

	#region Start
	// Use this for initialization
	void Start () {
	
		//initialize
		player = GameObject.FindGameObjectWithTag("Player");
		pHealth = player.GetComponentInChildren<PlayerHealth>();
		gun = player.GetComponentInChildren<LoveGun>();
		reTimer = delay;

	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
	
		//make the pickup always face the player (since it's just a quad)
		transform.rotation = Quaternion.LookRotation(transform.position - player.GetComponentInChildren<Camera>().transform.position);

		//tell everything to disable if the player runs into the pickup
		if (disable)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
			gameObject.GetComponent<ParticleSystem>().Stop();
			gameObject.GetComponent<ParticleSystem>().Clear();

			//start a timer for when to come back to life
			if (reTimer > 0)
			{
				reTimer -= Time.deltaTime;
				if (reTimer <= 0)
				{
					gameObject.GetComponent<Renderer>().enabled = true;
					gameObject.GetComponent<Collider>().enabled = true;
					gameObject.GetComponent<ParticleSystem>().Play();
					reTimer = delay;
					disable = false;
				}
			}
		}
	}
	#endregion

	#region OnTriggerEnter
	void OnTriggerEnter(Collider col)
	{
		//give the player ammo and health then disable itself
		if (col.gameObject.tag == "Player")
		{
			gun.ammo += ammoUp;
			pHealth.health += healthUp;
			disable = true;
		}
	}
	#endregion
}
