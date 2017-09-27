using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

	//script variables
	public HateGun gun;
	public Enemy enemy;

	void Awake() {

		//find the enemy script attached to a child of this instance of Enemy
		enemy = gameObject.GetComponentInChildren<Enemy>();

		//the gun script was attached manually via inspector
	}

	void Update() {

		//destroy this parent object if the enemy child has been destroyed
		if (enemy == null)
		{
			Debug.Log ("enemyBody doesn't exist!");
			Destroy (gameObject);
		}

	}

	void OnTriggerStay (Collider col)
	{
		//when the player is in range, track them and shoot them
		if (col.tag == "Player2")
		{
			transform.LookAt (col.transform);
			gun.isFiring = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		//stop shooting when the player is out of range
		gun.isFiring = false;
	}
}
