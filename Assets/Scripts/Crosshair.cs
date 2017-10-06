using UnityEngine;
using System.Collections;

//controls the crosshair creation and placement

public class Crosshair : MonoBehaviour {

	#region Variables
	//variables to be set in inspector
	public Texture2D crosshairTexture;		//the image for the crosshair
	public float crosshairScale = 1;		//the scale of the crosshair

	//variables for equations
	float crosshairWidth;					//the width of the crosshair
	float crosshairHeight;					//the height of the crosshair
	//float xMin;								//minimum x position
	//float yMin;								//minimum y position

	//other variables
	Pause pauseScript;						//reference to the pause script
	#endregion

	#region Start
	void Start()
	{
		//factor in scale
		crosshairWidth = crosshairTexture.width * crosshairScale;
		crosshairHeight = crosshairTexture.height * crosshairScale;

		if(GameObject.Find("UI") != null)
		{
			pauseScript = GameObject.Find("UI").GetComponent<Pause>();
		}
	}
	#endregion

	#region OnGUI
	void OnGUI()
	{

		//crosshair at mouse position
		/*
		xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairWidth / 2);
		yMin = (Screen.height - Input.mousePosition.y) - (crosshairHeight / 2);

		GUI.DrawTexture(new Rect(xMin, yMin, crosshairWidth, crosshairHeight), crosshairTexture);
		*/


		//crosshair at center of screen when the game isn't paused
		if (crosshairTexture != null)
		{
			if (pauseScript != null)
			{
				if(!pauseScript.Paused)
				{
					GUI.DrawTexture(new Rect((Screen.width-crosshairWidth)/2 ,(Screen.height-crosshairHeight)/2, 
						crosshairWidth, crosshairHeight),crosshairTexture);
				}
			}
			else
			{
				GUI.DrawTexture(new Rect((Screen.width-crosshairWidth)/2 ,(Screen.height-crosshairHeight)/2, 
					crosshairWidth, crosshairHeight),crosshairTexture);
			}

		}
		else
		{
			Debug.Log("No crosshair texture found!");
		}
	}
	#endregion
}
