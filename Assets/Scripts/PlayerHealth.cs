using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	#region Variables
	//health related variables
	public int startHealth = 100;
	public int health;
	public bool Dead;
	public bool Damaged;
	public Slider healthBar;

	//other variables
	private float timer = 5.0f;
	private LoveGun gunshot;
	public AudioSource deathScream;
	private CharacterController charMotor;
	public Crosshair crosshair;

	//screen fade variables
	public Image fadeIMG;
	public Color fadeColor;
	public float fadeTime = 3f;

	//screen flash variables
	public Image dmgFlash;
	public Color flashColor;
	public float flashTime = 5f;
	#endregion





	#region Awake
	// initialize when object is ready
	void Awake () {
		gunshot = GetComponentInChildren<LoveGun>();
		charMotor = GetComponent<CharacterController>();
		health = startHealth;
		healthBar.value = startHealth;
		fadeIMG.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
		dmgFlash.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
		fadeIMG.color = Color.clear;
		dmgFlash.color = Color.clear;

	}
	#endregion

	#region Update
	// Update is called once per frame
	void Update () {
	
		//fade screen to black and reload level if player dies
		if (Dead)
		{
			ScreenFade ();
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				Application.LoadLevel (Application.loadedLevel);
			}

		}

		//set a max level of health
		if (health > startHealth)
		{
			health = startHealth;
		}
		healthBar.value = health;

		//call method for damage effects
		DamageFlash();

	}
	#endregion

	#region TakeDamage
	//track the amount of damage the player has taken
	public void TakeDmg(int amount)
	{
		Damaged = true;
		health -= amount;
		healthBar.value = health;
		Debug.Log ("Ouch!");
		if (health <= 0 && !Dead)
		{
			Death();
		}
	}
	#endregion

	#region DamageFlash
	//create an effect when player gets damaged
	void DamageFlash()
	{
		if (Damaged)
		{
			dmgFlash.color = flashColor;
		}
		else
		{
			dmgFlash.color = Color.Lerp(dmgFlash.color, Color.clear,flashTime * Time.deltaTime);
		}
		Damaged = false;
	}
	#endregion

	#region Death
	//disable player control upon death
	void Death()
	{
		Dead = true;
		deathScream.Play();
		charMotor.enabled = false;
		gunshot.enabled = false;

	}
	#endregion

	#region ScreenFade
	//fade screen to black
	void ScreenFade()
	{
		fadeIMG.transform.SetAsLastSibling ();
		fadeIMG.color = Color.Lerp(fadeIMG.color, fadeColor, fadeTime * Time.deltaTime);
		crosshair.enabled = false;
	}
	#endregion
}
