using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl2GameController : MonoBehaviour {
    // Private
    private GameObject[] _lights;
    private WaitForSeconds _waitTime = new WaitForSeconds(5.0f);
    private bool _gamejuststart;

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
        DisplayText.gameObject.SetActive(true);
        DisplayText.text = "Turn on the Lights";
        StartCoroutine(_removeDisplay());
    }
	
	// Update is called once per frame
	void Update () {
        if (_gamejuststart)
        {
            DisplayText.gameObject.SetActive(true);
            DisplayText.text = "Turn on the Lights";
        }
    }

    private IEnumerator _removeDisplay()
    {
        yield return this._waitTime;
        _gamejuststart = false;
        DisplayText.gameObject.SetActive(false);
    }
}
