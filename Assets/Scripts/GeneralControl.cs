using UnityEngine;
using System.Collections;

public class GeneralControl : MonoBehaviour {

	//script to keep cursor from appearing and going off screen
	//as well as to allow a button to quit the game
	CursorLockMode desiredState;

	// Use this for initialization
	void Start () {
	
		desiredState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
	
		SetCursorState ();

		//quit game when escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}

	}

	// Apply requested cursor state
	void SetCursorState ()
	{
		Cursor.lockState = desiredState;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != desiredState);
	}
}
