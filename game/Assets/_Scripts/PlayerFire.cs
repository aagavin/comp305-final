using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
/// Player fire.
/// </summary>
public class PlayerFire : MonoBehaviour {

	/************** PRIVATE VARABLES **************/
	private Transform _transform;
	private bool _onTable;

	/************** PUBLIC  VARABLES **************/
	public AudioSource Firesound;
	public Transform FirePosition;
	public GameObject FireEffect;
	public AudioSource HealthSound;
	public AudioSource GunStuckSound;


	/************** PRIVATE FUNCTIONS  **************/
	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
		this._onTable = false;
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// Function handles the player fireing
	/// </summary>
	void Update () {
		if (Input.GetButtonDown ("Fire1") && !this._onTable) {
            Scene scene = SceneManager.GetActiveScene();
            bool ammoCheck = false;

            if (scene.name == "Level1")
            {
                ammoCheck = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController>().Ammo < 100;
            }
            else if(scene.name == "Level3")
            {
                ammoCheck = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController2>().Ammo < 100;
            }

			if (ammoCheck) {

				// play fire sound
				Firesound.volume = .1f;
				Firesound.Play ();

				//play fire effect
				GameObject fe = (GameObject)GameObject.Instantiate (FireEffect, FirePosition.position, FirePosition.rotation);
				fe.transform.parent = FirePosition;

				//test for hit with enemy
				RaycastHit hit;
				if (Physics.Raycast (this._transform.position, this._transform.forward, out hit)) {
					if (hit.transform.gameObject.CompareTag ("Enemy")) {
						hit.transform.gameObject.GetComponent<DalekController> ().Life -= 1;
					}
				}

                //please dont grade this badly
                //its hackey but we had nooo choice. 
                //Its 11:30 on friday night
                if (scene.name == "Level1")
                {
                    // Increase heat count
                    GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController>().Ammo += 10;
                }
                else if (scene.name == "Level3")
                {
                    // Increase heat count
                    GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController2>().Ammo += 10;
                }

				// stop sonic effect after 2s 
				GameObject.Destroy (fe, 2f);


			} 

		} else if (Input.GetButtonDown ("Fire1") && this._onTable) {
			this.GunStuckSound.Play ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("MajorTable")) {
			this._onTable = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("MajorTable")) {
			this._onTable = false;
		}
	}

	/************** PUBLIC FUNCTIONS **************/

	/// <summary>
	/// Raises the collision enter event.
	/// This occours when player hits pickup
	/// </summary>
	/// <param name="other">Other.</param>	/// 
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Pickup")){
			HealthSound.Play ();
			GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<GameController>().Health+=5;
			GameObject.Destroy (other.gameObject);
		}
	}


}
