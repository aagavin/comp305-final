﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Pedro Bento
 * Aaron Fernandes
 * Waynell Lovell
 * Ashley Tjonhing
 * 
 * 
 * COMP 305 - Assignment 4 | Final 
 */ 


/// <summary>
/// Game controller for level 3.
/// </summary>
public class GameController2 : MonoBehaviour {



	/************** PRIVATE VARIABLES **************/
	private int _score;
	private int _health;
	private int _ammo;
	private bool _invulnerable;
	private GameObject[] Spawnpoints;
	private int _waveNum =1;
	private int _enemySpawnCount;
	private float _invulnerableTime;
    private bool hasKey;


	/************** PUBLIC  VARIABLES **************/
	public Text ScoreText;
	public Text HealthText;
	public Text AmmoText;
    public Text Indication;

	public Text GameOverText;
	public Button RestartButton;

	public Transform Enemy;
	public Transform Pickup;
    public Transform KeyPickup;

    public GameObject keySpawn;

	public AudioSource GameOverSound;
	public AudioSource ThemeSound;
    public AudioSource GunReloadSound;

    /************** PUBLIC  PROPERTIES **************/


    /// <summary>
    /// Gets or sets the dalek spawn count.
    /// </summary>
    /// <value>The dalek spawn count.</value>
    public int DalekSpawnCount {
		get{
			return _enemySpawnCount;
		}
		set{
			this._enemySpawnCount = value;
			if (this._enemySpawnCount == 0) {
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
			return this._ammo;
		}
		set{
			this._ammo = value;
			AmmoText.text = "Heat: "+this._ammo+"%";
			if (Ammo == 100) {
				AmmoText.color = Color.red;
				Invoke ("_resetAmmo", 8f);		
			}
			else if(Ammo > 80){
				Invoke ("_resetAmmo", 3.5f);
			} else if (Ammo <= 15) {
				AmmoText.color = Color.white;
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
			HealthText.text = "Health: " + this.Health;
		}
	}
	
    /// <summary>
    /// Whether the player has picked up the key yet
    /// </summary>
    public bool HasKey
    {
        get { return this.hasKey; }
        set { this.hasKey = value; }
    }

	/************** PRIVATE FUNCTIONS  **************/

	/// <summary>
	/// Used for initialization of 
	/// varables
	/// </summary>
	void Start () {
		this._invulnerable = false;
        this.hasKey = false;
		this._health = 100;
		this._ammo = 0;
		AmmoText.text = "Heat: " + this._ammo + "%";
		this._invulnerableTime = 1.5f;

		Spawnpoints = GameObject.FindGameObjectsWithTag ("Spawnpoint");
		this._spawnDaleks ();

		// hide end game stuff
		GameOverText.gameObject.SetActive(false);
		RestartButton.gameObject.SetActive(false);

		//spawn keys
		this._spawnKey();
        StartCoroutine(_indication(new WaitForSeconds (3.0f), 1));
	}

    private IEnumerator _indication(WaitForSeconds _waitTime, int switchcase)
    {
        switch(switchcase)
        {
            case 1:
                Indication.text = "Oh No!";
                yield return _waitTime;
                StartCoroutine(_indication(new WaitForSeconds(3.0f), 2));
                break;
            case 2:
                Indication.text = "They are here also.";
                yield return _waitTime;
                StartCoroutine(_indication(new WaitForSeconds(3.0f), 3));
                break;
            case 3:
                Indication.text = "Kill them, find the key and GET OUT OF HERE.";
                StartCoroutine(_removeDisplay(new WaitForSeconds(3.0f)));
                break;
            default:
                yield return _waitTime;
                break;
        }
    }


    private IEnumerator _removeDisplay(WaitForSeconds _waitTime)
    {
        yield return _waitTime;
        Indication.gameObject.SetActive(false);
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
		this._enemySpawnCount = this._waveNum * 3;

		for (int i = 0; i < (this._waveNum * 3); i++) {
			int rand = Random.Range (0, 4);
			Vector3 position = (Spawnpoints [rand]).transform.position;
			Instantiate (Enemy, position, Quaternion.identity);

			//spawn player pickup on random locations
			if (Random.Range(0,10) % 2 ==0 && Health < 100) {
				Transform go = (Transform) Instantiate (Pickup, position, Quaternion.identity);
				GameObject.Destroy (go.gameObject, 30f);
			}
		}
	}

    private List<GameObject> GetChildren(GameObject parentObject)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform childTransform in parentObject.transform)
        {
            children.Add(childTransform.gameObject);
        }
        return children;
    }

    /// <summary>
    /// Spawns the key at a randomly-chosen KeySpawn.
    /// </summary>
    private void _spawnKey()
    {
        List<GameObject> keySpawnList = GetChildren(keySpawn);
        int rand = Random.Range(1, keySpawnList.Count);
        Instantiate(KeyPickup, keySpawnList[(int)rand].transform.position, Quaternion.identity);

    }

	/// <summary>
	/// Resets the ammo.
	/// </summary>
	private void _resetAmmo(){
		this.Ammo = 0;
		this.AmmoText.color = Color.white;
        this.GunReloadSound.Play();
    }

	/// <summary>
	/// Reset this instance.
	/// </summary>
	public void ResetGame(){
		int highScore = PlayerPrefs.GetInt ("Score");
		if (this._score > highScore) {
			PlayerPrefs.SetInt ("Score", this._score);
		}
	
		Time.timeScale = 1;

		SceneManager.LoadScene (0);
	}

	void Update(){
		if (Input.GetKeyDown ("0")) {
			this.HasKey = true;
		}
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

				Time.timeScale=0;

				this.ScoreText.gameObject.SetActive(false);
				this.HealthText.gameObject.SetActive(false);
				this.AmmoText.gameObject.SetActive(false);

				GameOverText.gameObject.SetActive(true);
				RestartButton.gameObject.SetActive(true);

				int highScore = PlayerPrefs.GetInt ("HighScore");
				if (this._score > highScore) {
					PlayerPrefs.SetInt ("HighScore", this._score);
				}
				GameOverText.text="Game Over High Score: "+PlayerPrefs.GetInt ("HighScore");
				Cursor.lockState = CursorLockMode.None;
			}
			this._setInvulnerable ();
		}
	}

    public void Win()
    {
		PlayerPrefs.SetInt ("Score", this._score);
        SceneManager.LoadScene("GameOver");
    }
}
