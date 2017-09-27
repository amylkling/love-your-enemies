using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	//variables to be set in inspector
	public Texture2D crosshairTexture;
	public float crosshairScale = 1;

	//variables for equations
	float crosshairWidth;
	float crosshairHeight;
	float xMin;
	float yMin;

	void Start()
	{
		//factor in scale
		crosshairWidth = crosshairTexture.width * crosshairScale;
		crosshairHeight = crosshairTexture.height * crosshairScale;
	}


	void OnGUI()
	{

		//crosshair at mouse position
		/*
		xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairWidth / 2);
		yMin = (Screen.height - Input.mousePosition.y) - (crosshairHeight / 2);

		GUI.DrawTexture(new Rect(xMin, yMin, crosshairWidth, crosshairHeight), crosshairTexture);
		*/


		//crosshair at center of screen
		if (crosshairTexture != null)
		{
			GUI.DrawTexture(new Rect((Screen.width-crosshairWidth)/2 ,(Screen.height-crosshairHeight)/2, 
			                         crosshairWidth, crosshairHeight),crosshairTexture);
		}
		else
		{
			Debug.Log("No crosshair texture found!");
		}
	}
}
