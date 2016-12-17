using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Pedro Bento
 * Aaron Fernandes
 * Waynell Lovell
 * Ashley Tjonhing (is blissfully unaware of this bad code, please dont tell her )
 * 
 * 
 * COMP 305 - Assignment 4 | Final 
 */


/// <summary>
/// Game controller.
/// </summary>
public class GameController : MonoBehaviour {



	/************** PRIVATE VARABLES **************/
	private int _score;
	private int _health;
	private int _amo;
	private bool _invulnerable;
	private GameObject[] Spawnpoints;
	private int _waveNum =1;
	private int _waveMod=10;
	private int _dalekSpawnCount;
	private float _invulnerableTime;


	/************** PUBLIC  VARABLES **************/
	public Text ScoreText;
	public Text HelthText;
	public Text AmoText;
    public Text Instructions;

	public Text GameOverText;
	public Button RestartButton;

	public Transform Dalek;
	public Transform Pickup;

	public AudioSource GameOverSound;
	public AudioSource ThemeSound;
	public AudioSource GunReloadSound;

	public MenuScript MenUScript;

	/************** COROUTINE  PROPITIES **************/

	IEnumerator ScoreManagnment(){
		//
		yield return new WaitForSeconds(2);
		this.Ammo -= 5;
		StartCoroutine ("ScoreManagnment");
	}
    IEnumerator Indications(WaitForSeconds _waitTime)
    {
        Instructions.text = "SURVIVE";
        yield return _waitTime;
        StartCoroutine(Indications2(new WaitForSeconds(3.0f)));
    }
    IEnumerator Indications2(WaitForSeconds _waitTime)
    {
        Instructions.text = "Kill All Enemies!!";
        yield return _waitTime;
        Instructions.gameObject.SetActive(false);
    }

    /************** PUBLIC  PROPITIES **************/


    /// <summary>
    /// Gets or sets the dalek spawn count.
    /// </summary>
    /// <value>The dalek spawn count.</value>
    public int DalekSpawnCount {
		get{
			return _dalekSpawnCount;
		}
		set{
			this._dalekSpawnCount = value;
			if (this._dalekSpawnCount == 0) {
				this._waveNum++;
				this._spawnDaleks ();
			}
		}
	}

	/// <summary>
	/// Gets or sets the score.
	/// </summary>
	/// <value>The score.</value>
	public int Score {
		get{
			return this._score;
		}
		set{
			this._score = value;
			ScoreText.text = "Score: " + this._score;

		}
	}

	/// <summary>
	/// Gets or sets the amo.
	/// </summary>
	/// <value>The amo.</value>
	public int Ammo {
		get{
			return this._amo;
		}
		set{
			if (value>0 || value<100) {
				this._amo = value;
				AmoText.text = "Heat: "+this._amo+"%";
				if (Ammo == 100) {
					AmoText.color = Color.red;
					Invoke ("_resetAmo", 8f);		
				}
				else if(Ammo > 60 && Ammo < 100){
					AmoText.color = Color.yellow;
				} else if (Ammo <= 15) {
					AmoText.color = Color.white;
				}			
			}
		}
	}

	/// <summary>
	/// Gets or sets the health.
	/// </summary>
	/// <value>The health.</value>
	public int Health {
		get{
			return this._health;
		}
		set{
			this._health = value;
			HelthText.text = "Health: " + this.Health;
		}
	}
		

	/************** PRIVATE FUNCTIONS  **************/

	/// <summary>
	/// Used for initialization of 
	/// varables
	/// </summary>
	void Start () {
		this._invulnerable = false;
		this._health = 100;
		this._amo = 0;
		AmoText.text = "Heat: " + this._amo + "%";
		this._invulnerableTime = 1.5f;

		Spawnpoints = GameObject.FindGameObjectsWithTag ("Spawnpoint");
		this._spawnDaleks ();

		// hide end game stuff
		GameOverText.gameObject.SetActive(false);
		RestartButton.gameObject.SetActive(false);
		PlayerPrefs.SetInt ("HighScore", 0);

		//start corouitne
		StartCoroutine ("ScoreManagnment");
        StartCoroutine(Indications(new WaitForSeconds(3.0f)));
	}

	void Update(){
		if (this.Score == 50) {
			PlayerPrefs.SetInt ("Score", this.Score);
			MenUScript.level1to2button_Click ();
		}
	}


	/// <summary>
	/// Makes the player Invulnerable for <invulnerableTime>
	/// </summary>
	private void _setInvulnerable(){
		this._invulnerable = true;
		Invoke("_setVulnerable", _invulnerableTime);

	}

	/// <summary>
	/// Sets the vulnerablity
	/// </summary>
	private void _setVulnerable(){
		this._invulnerable = false;
	}


	/// <summary>
	/// Spawns the daleks.
	/// </summary>
	private void _spawnDaleks(){
		this._dalekSpawnCount = this._waveNum * this._waveMod;

		for (int i = 0; i < (this._waveNum * this._waveMod); i++) {
			int rand = Random.Range (0, 4);
			Vector3 position = (Spawnpoints [rand]).transform.position;
			Instantiate (Dalek, position, Quaternion.identity);

			//spawn player pickup on random locations
			if (Random.Range(0,10) % 2 ==0 && Health < 100) {
				Transform go = (Transform) Instantiate (Pickup, position, Quaternion.identity);
				GameObject.Destroy (go.gameObject, 30f);
			}
		}
	}

	/// <summary>
	/// Resets the amo.
	/// </summary>
	private void _resetAmo(){
		this.Ammo = 0;
		this.AmoText.color = Color.white;
		this.GunReloadSound.Play ();
	}

	/// <summary>
	/// Reset this instance.
	/// </summary>
	public void Reset(){
		int highScore = PlayerPrefs.GetInt ("HighScore");
		if (this._score > highScore) {
			PlayerPrefs.SetInt ("HighScore", this._score);
		}
	
		Time.timeScale = 1;

		SceneManager.LoadScene (0);
	}

	/************** PUBLIC FUNCTIONS **************/

	/// <summary>
	/// Hit function
	/// </summary>
	public void HealthHit(){
		if (!this._invulnerable) {
			this.Health -= 10;
			if (this.Health <= 0) {
				//Change sounds
				ThemeSound.Stop ();
				GameOverSound.Play();

				//
				Time.timeScale=0;


				this.ScoreText.gameObject.SetActive(false);
				this.HelthText.gameObject.SetActive(false);
				this.AmoText.gameObject.SetActive(false);

				GameOverText.gameObject.SetActive(true);
				RestartButton.gameObject.SetActive(true);

				int highScore = PlayerPrefs.GetInt ("HighScore");
				if (this._score > highScore) {
					PlayerPrefs.SetInt ("HighScore", this._score);
				}
				SceneManager.LoadScene ("GameOver");
				//GameOverText.text="Game Over High Score: "+PlayerPrefs.GetInt ("HighScore");
				//Cursor.lockState = CursorLockMode.None;

			}
			this._setInvulnerable ();
		}

	}
}
