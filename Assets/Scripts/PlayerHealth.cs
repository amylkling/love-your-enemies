using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//controls the health state of the player

public class PlayerHealth : MonoBehaviour {

	#region Variables
	//health related variables
	public int startHealth = 100;					//amount of health to start with
	public int health;								//current amount of health
	public bool Dead;								//the state of death
	public bool Damaged;							//the state of being damaged
	public Slider healthBar;						//the actual health bar

	//other variables
	private float timer = 5.0f;						//timer for death screen fade
	private LoveGun gunshot;						//reference to the lovegun script
	public AudioSource deathScream;					//audio plays upon death
	private CharacterController charMotor;			//reference to the character controller script
	public Crosshair crosshair;						//reference to the crosshair script

	//screen fade variables
	public Image fadeIMG;							//the image to fade into
	public Color fadeColor;							//the color of the fade image
	public float fadeTime = 3f;						//the speed of the fade

	//screen flash variables
	public Image dmgFlash;							//the image that flashes on screen
	public Color flashColor;						//the color of the image flash
	public float flashTime = 5f;					//the speed of the flash
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
				SceneManager.LoadScene(0);
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
