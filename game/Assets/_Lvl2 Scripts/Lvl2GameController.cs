using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2GameController : MonoBehaviour {
    // Private
    private GameObject[] _lights;

    //public
    public AudioSource backgroundmusic;

    // Use this for initialization
    void Start () {
        _lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in _lights)
        {
            var source = light.GetComponent<Light>();
                source.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
