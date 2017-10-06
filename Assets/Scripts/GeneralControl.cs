using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//script to keep cursor from appearing and going off screen
//as well as releasing the cursor when in menus

public class GeneralControl : MonoBehaviour {

	#region Variables
	CursorLockMode desiredState;
	Pause pauseScript;
	#endregion

	#region Start
	// Use this for initialization
	void Start () {
	
		desiredState = CursorLockMode.Locked;
		if(GameObject.Find("UI") != null)
		{
			pauseScript = GameObject.Find("UI").GetComponent<Pause>();
		}
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
	
		//check for the existance of the pause menu
		if (pauseScript != null)
		{
			//lock the cursor when the game isn't paused and not on the main menu
			if(!pauseScript.Paused && SceneManager.GetActiveScene().name != "menu")
			{
				desiredState = CursorLockMode.Locked;
			}
			else
			{
				desiredState = CursorLockMode.None;
			}
		}
		else
		{
			desiredState = CursorLockMode.Locked;
		}


		SetCursorState ();

		/*
		//quit game when escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}*/
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
