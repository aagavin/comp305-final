using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2GameController : MonoBehaviour {
    // Private
    private GameObject[] _lights;

    //public
    public AudioSource backgroundmusic;
    public GameObject Player;
    public Transform SpawnPoint;

    // Use this for initialization
    void Start () {
        _lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in _lights)
        {
            var source = light.GetComponent<Light>();
                source.enabled = false;
        }
        this.Player.transform.position = this.SpawnPoint.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
