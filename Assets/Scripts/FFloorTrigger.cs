using UnityEngine;
using System.Collections;

public class FFloorTrigger : MonoBehaviour {

	//objects to be enabled/disabled
	public GameObject secondFloorObj;
	public GameObject firstFloorObj;
	public GameObject secondFloorTrigger;
	
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			//activates the second floor trigger, activates the first floor, deactivates the second floor and deactivates itself
			secondFloorObj.SetActive (false);
			firstFloorObj.SetActive (true);
			secondFloorTrigger.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
