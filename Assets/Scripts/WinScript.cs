using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//determines what the win state is and what happens when it's reached

public class WinScript : MonoBehaviour {

	#region Variables
	//timer variables
	float restartTimer;								//timer until restart
	float instructTimer;							//timer for displaying instructions
	public float instructTimerDelay = 10.0f;		//time to wait between instructions
	public float restartTimerDelay = 5.0f;			//time to wait until restart

	//GUI variables
	public Text winGUI;								//text that displays when the player wins
	public Text enemyCount;							//text displaying the remaining enemies
	public Text instructGUI;						//instruction text 1
	public Text instructGUI2;						//instruction text 2

	//counting variable
	public int count;								//the number of enemies left in the game
	public GameObject[] enemyParent;				//array of objects holding enemy objects

	//other variable
	public GameObject secondFloor;					//the object representing the second floor
	#endregion

	#region Start
	// Use this for initialization
	void Start () {
	
		//initialize everything
		count = gameObject.transform.childCount;
		restartTimer = restartTimerDelay;
		instructTimer = instructTimerDelay;
		winGUI.enabled = false;
		enemyParent = GameObject.FindGameObjectsWithTag ("Parent");
		secondFloor.SetActive (false);
		instructGUI2.enabled = false;
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
	
		//count how many enemies exist and display on screen
		count = gameObject.transform.childCount;
		foreach (GameObject parent in enemyParent)
		{
			count += parent.transform.childCount;
		}
		enemyCount.text = "Enemies: " + count.ToString ("00");

		//keep the instructions on screen for a certain amount of time
		if (instructGUI.enabled == true) 
		{
			if (instructTimer > 0) 
			{
				instructTimer -= Time.deltaTime;
				if (instructTimer <= 0) 
				{
					instructTimer = instructTimerDelay;
					instructGUI.enabled = false;
					instructGUI2.enabled = true;
				}
			}
		}

		if (instructGUI2.enabled == true) 
		{
			if (instructTimer > 0) 
			{
				instructTimer -= Time.deltaTime;
				if (instructTimer <= 0) 
				{
					instructGUI2.enabled = false;
				}
			}
		}


		//set win condition; player kills all enemies, game restarts
		if (count == 0)
		{
			winGUI.enabled = true;
			if (restartTimer > 0)
			{
				restartTimer -= Time.deltaTime;
				if (restartTimer <= 0)
				{
					SceneManager.LoadScene(0);

				}
			}
		}

	}
	#endregion
}
