using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* * Pedro Bento
* Aaron Fernandes
* Waynell Lovell
* Ashley Tjonhing
* 
* 
* COMP 305 - Assignment 4 | Final 
*/

public class Lvl2GameController : MonoBehaviour {
    // Private
    private GameObject[] _lights;
    private bool _gamejuststart;
    private bool _instruction;
    private bool _warning;

    //public
    public AudioSource backgroundmusic;
    public GameObject Player;
    public Transform SpawnPoint;
    public Text DisplayText;

    // Use this for initialization
    void Start () {
        _lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in _lights)
        {
            Light source = (Light) light.GetComponent<Light>();
                source.enabled = false;
        }
        this.Player.transform.position = this.SpawnPoint.position;
        _gamejuststart = true;
        _instruction = false;
        DisplayText.gameObject.SetActive(true);
        DisplayText.text = "Turn on the Lights";
        StartCoroutine(_removeDisplay(new WaitForSeconds(3.0f)));
        StartCoroutine(_removeInstruction(new WaitForSeconds(5.0f)));
        StartCoroutine(_removeWarning(new WaitForSeconds(7.0f)));
    }
	
	// Update is called once per frame
	void Update () {
        if (_gamejuststart)
        {
            DisplayText.gameObject.SetActive(true);
            DisplayText.text = "Find Your Car";
        }
        else if(_instruction)
        {
            DisplayText.gameObject.SetActive(true);
            DisplayText.text = "Turn On the Lights";
        }
        else if(_warning)
        {
            DisplayText.gameObject.SetActive(true);
            DisplayText.text = "Don't get hit by Enemies";
        }
    }

    private IEnumerator _removeDisplay(WaitForSeconds _waitTime)
    {
        yield return _waitTime;
        _gamejuststart = false;
        _instruction = true;

    }
    private IEnumerator _removeInstruction(WaitForSeconds _waitTime)
    {
        yield return _waitTime;
        _instruction = false;
        _warning = true;
    }
    private IEnumerator _removeWarning(WaitForSeconds _waitTime)
    {
        yield return _waitTime;
        _warning = false;
    }
}
