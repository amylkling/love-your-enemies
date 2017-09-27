using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunShot : MonoBehaviour {

	//public GameObject spot;
	public int ammo = 100;
	public int damageAmount = 10;
	public float raycastDist = 100.0f;
	public GameObject bullet;
	//public AudioClip Gunshot;
	//public AudioClip Dryfire;

	public Text ammoGUI;

	public Turret turret;

	void Start()
	{
		UpdateGUI();
	}


	// Update is called once per frame
	void Update () {
	
		//RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			if (ammo > 0)
			{
				Instantiate (bullet, transform.position, transform.rotation);
//				if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDist))
//				{
//
//					if (hit.collider.tag == "Enemy")
//					{
//						turret = hit.collider.GetComponent<Turret>();
//						turret.TakeDmg(damageAmount);
//						Debug.Log ("Hit Enemy!");
//
//					}
//				}
				ammo--;
				UpdateGUI();
			}
		}

	}

	void UpdateGUI()
	{
		ammoGUI.text = "Ammo: " + ammo.ToString("00");
	}

}
