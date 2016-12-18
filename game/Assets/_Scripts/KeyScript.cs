using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

	private GameController2 gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("ScoreBoard").GetComponent<GameController2> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.HasKey = true;
            DestroyObject(this.gameObject);
        }
    }
}
