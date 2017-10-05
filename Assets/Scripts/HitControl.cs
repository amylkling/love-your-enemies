using UnityEngine;
using System.Collections;

//controls the shot hit particle

public class HitControl : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
		//destroy the object once the particles are done playing
		if(gameObject.GetComponent<ParticleSystem>().isStopped)
		{
			Destroy (gameObject);
		}

	}
}
