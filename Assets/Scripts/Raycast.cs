using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	float raycastDist = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) 
		{
			if (Physics.Raycast (transform.position,transform.forward,raycastDist))
			{
				Debug.Log ("Hit!");
			}
			else
			{
				Debug.Log ("No hit!");
			}
		}

	}
}
