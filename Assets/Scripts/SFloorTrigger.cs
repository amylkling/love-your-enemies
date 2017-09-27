using UnityEngine;
using System.Collections;

public class SFloorTrigger : MonoBehaviour {

	//objects to be enabled/disabled
	public GameObject secondFloorObj;
	public GameObject firstFloorObj;
	public GameObject firstFloorTrigger;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			//activates the first floor trigger, activates the second floor, deactivates the first floor and deactivates itself
			secondFloorObj.SetActive (true);
			firstFloorObj.SetActive (false);
			firstFloorTrigger.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
