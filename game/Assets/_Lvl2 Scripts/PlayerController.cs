using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Public
    public Transform PlayerDirection;
    public Transform Respawn;
    public Text DisplayText;
    public AudioSource PhoneCall;
    public AudioSource Sit;
    public AudioSource GetinCar;
    public AudioSource CarAttempt;

    // Private
    private GameObject[] _lights;
    private bool _isLightsOn;

	// Use this for initialization
	void Start () {
        DisplayText.gameObject.SetActive(false);
        _lights = GameObject.FindGameObjectsWithTag("Light");
        _isLightsOn = true;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        // need a variable to hold the location of our Raycast look
        RaycastHit look;

        //if raycast hits an object then do somthing....
        if(Physics.Raycast (this.PlayerDirection.position, this.PlayerDirection.forward, out look,5f))
        {
            if (look.transform.gameObject.CompareTag("Phone"))
            {
                DisplayText.gameObject.SetActive(true);
                DisplayText.text = "Try calling home?";
            }
            else if (look.transform.gameObject.CompareTag("Power"))
            {
                DisplayText.gameObject.SetActive(true);
                DisplayText.text = "Turn On/Off the lights";
            }
            else if (look.transform.gameObject.CompareTag("Bench"))
            {
                DisplayText.gameObject.SetActive(true);
                DisplayText.text = "Take a sit";
            }
            else if(look.transform.gameObject.CompareTag("Car")|| look.transform.gameObject.CompareTag("Enemy"))
            {
                DisplayText.gameObject.SetActive(true);
                DisplayText.text = "Try to open car";
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (Physics.Raycast(this.PlayerDirection.position, this.PlayerDirection.forward, out look, 5f))
                {
                    if (look.transform.gameObject.CompareTag("Phone"))
                    {
                        PhoneCall.Play();
                        DisplayText.gameObject.SetActive(false);
                        DisplayText.text = "";
                    }
                    else if (look.transform.gameObject.CompareTag("Enemy"))
                    {
                        CarAttempt.Play();
                        look.transform.SendMessage("Follow");
                        look.collider.SendMessage("Follow");
                    }
                    else if(look.transform.gameObject.CompareTag("Car"))
                    {
                        CarAttempt.Play();
                    }
                    else if(look.transform.gameObject.CompareTag("Bench"))
                    {
                        Sit.Play();
                        DisplayText.gameObject.SetActive(false);
                        DisplayText.text = "";
                    }
                    else if (look.transform.gameObject.CompareTag("Power"))
                    {
                        foreach (GameObject light in _lights)
                        {
                            var source = light.GetComponent<Light>();
                            if (_isLightsOn)
                                source.enabled = false;
                            else
                                source.enabled = true;
                        }
                        _isLightsOn = !_isLightsOn;
                        DisplayText.gameObject.SetActive(false);
                        DisplayText.text = "";
                    }
                }
            }
        }
        else
        {
            DisplayText.gameObject.SetActive(false);
            DisplayText.text = "";
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        PlayerDirection.position = Respawn.position;
    }
}
