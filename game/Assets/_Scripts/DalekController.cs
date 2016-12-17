using UnityEngine;
using System.Collections;
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
/// Dalek controller.
/// </summary>
public class DalekController : MonoBehaviour {


	/************** PRIVATE VARABLES **************/


	private Transform _player;
	private GameObject _gameController;
	private int _life;

	/************** PUBLIC  VARABLES **************/
	public UnityEngine.AI.NavMeshAgent Agent;
	public AudioClip DeathSound;

	public int Life {
		get{
			return this._life;
		}
		set{
			this._life = value;
			if(this._life==0){
				Scene scene = SceneManager.GetActiveScene();

				if (scene.name == "Level3") {
					this._gameController.GetComponent<GameController2> ().DalekSpawnCount--;
					this._gameController.GetComponent<GameController2> ().Score += 5;
					AudioSource.PlayClipAtPoint (DeathSound, this.transform.position, 50f);
					GameObject.Destroy (this.gameObject);
				} else {
					this._gameController.GetComponent<GameController> ().DalekSpawnCount--;
					this._gameController.GetComponent<GameController> ().Score += 5;
					AudioSource.PlayClipAtPoint (DeathSound, this.transform.position, 50f);
					GameObject.Destroy (this.gameObject);
				}
			}
		}
	}

	/************** PRIVATE FUNCTIONS  **************/

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		this._gameController = GameObject.FindGameObjectWithTag ("ScoreBoard");
		this._player = GameObject.FindWithTag ("Player").transform;
		this._life = 2;
	}

	void Update(){
		this.Agent.SetDestination (this._player.position);
	}

	/************** PUBLIC FUNCTIONS **************/

	/// <summary>
	/// Raises the collision enter event
	/// when dalek hits player
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player") ){
			other.gameObject.GetComponent<Rigidbody> ().velocity *=-500;
            Scene scene = SceneManager.GetActiveScene();
            
            // sorry again
            // we are really really sorry

            if (scene.name == "Level3")
            {
                _gameController.GetComponent<GameController2>().HealthHit();
            }
            else
            {
                _gameController.GetComponent<GameController>().HealthHit();
            }

		}

	}
}
