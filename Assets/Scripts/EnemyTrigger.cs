using UnityEngine;
using System.Collections;

//functions as the enemy AI

public class EnemyTrigger : MonoBehaviour {

	#region Variables
	//script variables
	public HateGun gun;		//the gun script attached to this enemy's gun
	public Enemy enemy;		//this enemy's script
	#endregion

	#region Awake
	void Awake() {

		//find the enemy script attached to a child of this instance of Enemy
		enemy = gameObject.GetComponentInChildren<Enemy>();

		//the gun script is attached manually via inspector
	}
	#endregion

	#region Update
	void Update() {

		//destroy this parent object if the enemy child has been destroyed
		if (enemy == null)
		{
			Debug.Log ("enemyBody doesn't exist!");
			Destroy (gameObject);
		}
	}
	#endregion

	#region OnTriggerStay
	void OnTriggerStay (Collider col)
	{
		//when the player is in range, track them and shoot them
		if (col.tag == "Player2")
		{
			if(transform.GetChild(0) != null)
			{
				transform.GetChild(0).LookAt (col.transform);
			}

			gun.isFiring = true;
		}
	}
	#endregion

	#region OnTriggerExit
	void OnTriggerExit(Collider col)
	{
		//stop shooting when the player is out of range
		gun.isFiring = false;
	}
	#endregion
}
