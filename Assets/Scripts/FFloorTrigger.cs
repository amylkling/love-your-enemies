using UnityEngine;
using System.Collections;

//handles the activation of the first floor and deactivation of the second floor

public class FFloorTrigger : MonoBehaviour {

	#region Variables
	//objects to be enabled/disabled
	public GameObject secondFloorObj;
	public GameObject firstFloorObj;
	public GameObject secondFloorTrigger;
	#endregion

	#region OnTriggerEnter
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
	#endregion
}
