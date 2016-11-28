using UnityEngine;
using System.Collections;
/*
 * Pedro Bento
 * Aaron Fernandes
 * 
 * COMP 305 - Assignment 3
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
	public NavMeshAgent Agent;
	public AudioClip DeathSound;

	public int Life {
		get{
			return this._life;
		}
		set{
			this._life = value;
			if(this._life==0){
				this._gameController.GetComponent<GameController> ().DalekSpawnCount--;
				this._gameController.GetComponent<GameController> ().Score+=5;
				AudioSource.PlayClipAtPoint (DeathSound, this.transform.position, 50f);
				GameObject.Destroy (this.gameObject);
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
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player") ){
			other.gameObject.GetComponent<Rigidbody> ().velocity *=-500;

			_gameController.GetComponent<GameController> ().HealthHit ();

		}

	}
}
