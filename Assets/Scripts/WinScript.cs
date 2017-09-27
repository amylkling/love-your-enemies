using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

	//timer variables
	float restartTimer;
	float instructTimer;
	public float instructTimerDelay = 10.0f;
	public float restartTimerDelay = 5.0f;

	//GUI variables
	public Text winGUI;
	public Text enemyCount;
	public Text instructGUI;
	public Text instructGUI2;

	//counting variable
	public int count;
	public GameObject[] enemyParent;

	//other variable
	public GameObject secondFloor;

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
					Application.LoadLevel (Application.loadedLevel);

				}
			}
		}

	}
}
