using UnityEngine;
using System.Collections;

public class HitControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//destroy the object once the particles are done playing
		if(gameObject.GetComponent<ParticleSystem>().isStopped)
		{
			Destroy (gameObject);
		}

	}
}
