using UnityEngine;
using System.Collections;

//controls the enemy's gun

public class HateGun : MonoBehaviour {

	#region Variables
	//shooting variables
	public float initFireRate = 1f;		//how long to take between shots
	public float fireRate;				//timer for fire rate
	public float raycastDist = 30;		//the farthest it can shoot
	public GameObject shotHit;			//the particle effect prefab for when the shot hits something
	public int dmgamt = 10;				//the amount of damage each shot does
	public bool isFiring = false;		//whether the gun is currently firing
	public int initShots = 0;			//starting number of shots fired
	public int shotsLimit = 10;			//maximum number of shots that can be fired
	public int shots;					//current number of shots fired
	public float initReloadTime = 5f;	//how long to take to reload
	public float reloadTime;			//reload timer
	
	//sound variables
	private AudioSource damagedSound;	//audiosource to feed sounds to
	public AudioClip damaged;			//sound to play when the player gets damaged
	public AudioClip enemyShot;			//sound to play when the shot hits something other than the player
	public AudioClip enemyReload;		//sound for reloading
	#endregion

	#region Start
	// Use this for initialization
	void Start () {
	
		//initialize a few things
		damagedSound = gameObject.GetComponent<AudioSource>();
		shots = initShots;
		reloadTime = initReloadTime;
		fireRate = initFireRate;
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
		//create and initialize a variable for the PlayerHealth script
		PlayerHealth plhth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

		//initialize variable for Raycast hit detection
		RaycastHit hit;

		//isFiring is being controlled by EnemyTrigger script
		if (isFiring)
		{
			//limit how many shots can be fired before reload
			if (shots < shotsLimit)
			{
				//add a delay to limit how fast shots are being fired
				fireRate -= Time.deltaTime;
				if (fireRate < 0)
				{
					//when time runs out, shoot using Raycast
					if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
					{
						//cause player to take damage when the player isn't dead, but still shoot if it missed the player
						if (hit.collider.tag == "Player" || hit.collider.tag == "Player2")
						{
							if (!plhth.Dead)
							{
								Instantiate (shotHit, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
								plhth.TakeDmg(dmgamt);
								Debug.Log ("Hit Player!");
								damagedSound.PlayOneShot (damaged);
							}
							
						}
						else
						{
							Instantiate (shotHit, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
							damagedSound.PlayOneShot (enemyShot);
						}
					}
					fireRate = initFireRate;
					shots++;
				}
			}
			else
			{
				//when too many shots have been fired, stop shooting and take time to reload
				damagedSound.PlayOneShot(enemyReload);
				reloadTime -= Time.deltaTime;
				if (reloadTime < 0)
				{
					shots = initShots;
					reloadTime = initReloadTime;
				}
			}
		}
	}
	#endregion
}
