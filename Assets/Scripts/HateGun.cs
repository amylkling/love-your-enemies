using UnityEngine;
using System.Collections;

public class HateGun : MonoBehaviour {

	//shooting variables
	public float initFireRate = 1f;
	public float fireRate;
	public float raycastDist = 30;
	public GameObject shotHit;
	public int dmgamt = 10;
	public bool isFiring = false;
	public int initShots = 0;
	public int shotsLimit = 10;
	public int shots;
	public float initReloadTime = 5f;
	public float reloadTime;
	
	//sound variables
	private AudioSource damagedSound;
	public AudioClip damaged;
	public AudioClip enemyShot;
	public AudioClip enemyReload;


	// Use this for initialization
	void Start () {
	
		//initialize a few things
		damagedSound = gameObject.GetComponent<AudioSource>();
		shots = initShots;
		reloadTime = initReloadTime;
		fireRate = initFireRate;
	}
	
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
}
