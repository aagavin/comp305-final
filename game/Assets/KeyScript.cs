using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public GameController2 gameController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameController.HasKey = true;
            DestroyObject(this.gameObject);
        }
    }
}
