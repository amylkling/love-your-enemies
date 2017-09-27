using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//creates the enemy health bar and manages its position and visibility

public class EnemyUI : MonoBehaviour {

	#region Variables
	//script variables
	private Enemy enemyScript;					//this enemy's script
	public EnemyUIDirectControl uiScript;		//this enemy's UI control script

	//variables for creating GUI
	public Canvas canvas;						//the canvas to use
	public GameObject healthPrefab;				//the prefab for the health bar

	//variables for manipulating GUI
	public float healthPanelOffset = 2f;		//the y offset used when positioning the health bar
	public GameObject healthPanel;				//the health panel, which holds the health bar
	public Slider healthSlider;					//the health bar
	private Renderer selfRenderer;				//the renderer on this enemy
	private CanvasGroup canvasGroup;			//the canvasgroup on the health bar
	public float viewRange = 15f;				//the range at which the health bar can be seen
	#endregion

	#region Awake
	// Use this for initialization
	void Awake () {
		//initialize and instantiate
		enemyScript = gameObject.GetComponent<Enemy>();
		healthPanel = Instantiate(healthPrefab) as GameObject;
		healthPanel.transform.SetParent(canvas.transform, false);
		
		healthSlider = healthPanel.GetComponent<Slider>();
		selfRenderer = gameObject.GetComponent<Renderer>();

		//let the Enemy script attached to the same enemy know which health bar belongs to it
		enemyScript.healthBar = healthSlider;

		canvasGroup = healthPanel.GetComponent<CanvasGroup>();

		//this is purely so that this script can tell EnemyUIDirectControl script which enemy it is associated with
		uiScript = healthPanel.GetComponent<EnemyUIDirectControl>();
		uiScript.enemyScript = enemyScript;
	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {

		//position the health bar above the enemy
		Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + healthPanelOffset, transform.position.z);
		Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
		healthPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

		//track camera distance and make the health bar invisible when the player is far enough away
		float distance = (worldPos - Camera.main.transform.position).magnitude;
		float alpha = viewRange - distance / 2.0f;
		SetAlpha(alpha);

		//hide the health bar when the enemy is no longer visible
		if (selfRenderer.isVisible)
		{
			healthPanel.SetActive(true);
		}
		else
		{
			healthPanel.SetActive(false);
		}
	}
	#endregion

	#region SetAlpha
	//make health bar invisible
	public void SetAlpha(float alpha)
	{
		canvasGroup.alpha = alpha;
		
		if (alpha <= 0)
		{
			healthPanel.SetActive(false);
		}
		else
		{
			healthPanel.SetActive(true);
		}
	}
	#endregion
	
}
