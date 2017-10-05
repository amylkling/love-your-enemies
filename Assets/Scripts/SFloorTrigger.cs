using UnityEngine;
using System.Collections;

//handles the activation of the second floor and deactivation of the first floor

public class SFloorTrigger : MonoBehaviour {

	#region Variables
	//objects to be enabled/disabled
	public GameObject secondFloorObj;
	public GameObject firstFloorObj;
	public GameObject firstFloorTrigger;
	#endregion

	#region OnTriggerEnter
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
	#endregion
}
