﻿using UnityEngine;
using System.Collections;

//makes sure the enemy's health bar gets destroyed or deactivated with it

public class EnemyUIDirectControl : MonoBehaviour {

	#region Variables
	//script attached to an instance of Enemy Body
	public Enemy enemyScript;
	#endregion

	#region Start
	// Use this for initialization
	void Start () {
	
		//EnemyUI script is setting enemyScript to the exact instance of Enemy Body that 
		//this instance of Enemy Health is assigned to within EnemyUI script.

	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
	
		//destroy the health bar if the enemy is destroyed
		if (enemyScript == null)
		{
			Debug.Log ("enemyBody doesn't exist!");
			Destroy (gameObject);
		}
		//or deactivates the health bar if the enemy is deactivated
		else if (enemyScript.isActiveAndEnabled == false)
		{
			gameObject.SetActive (false);
		}
	}
	#endregion
}
