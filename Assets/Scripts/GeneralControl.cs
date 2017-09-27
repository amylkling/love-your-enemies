using UnityEngine;
using System.Collections;

//script to keep cursor from appearing and going off screen
//as well as to allow a button to quit the game

public class GeneralControl : MonoBehaviour {

	#region Variables
	CursorLockMode desiredState;
	#endregion

	#region Start
	// Use this for initialization
	void Start () {
	
		desiredState = CursorLockMode.Locked;
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
	
		SetCursorState ();

		//quit game when escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}
	}
	#endregion

	#region SetCursorState
	// Apply requested cursor state
	void SetCursorState ()
	{
		Cursor.lockState = desiredState;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != desiredState);
	}
	#endregion
}
