using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private Transform barrel;
	public float bspeed = 5000.0f;
	private Turret enemy;

	// Use this for initialization
	void Start () {
		barrel = GameObject.FindGameObjectWithTag ("Barrel").transform;
		GetComponent<Rigidbody>().AddForce (barrel.forward * bspeed);
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, .5f);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			enemy = col.gameObject.GetComponent<Turret>();
			enemy.TakeDmg (10);
			Destroy (gameObject);
		}
	}
}
