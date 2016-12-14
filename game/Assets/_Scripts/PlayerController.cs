using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // Public
    public Transform PlayerDirection;
    public Transform Respawn;
    public Text DisplayText;
    public AudioSource PhoneCall;
    public AudioSource Sit;
    public AudioSource GetinCar;
    public AudioSource CarAttempt;
    public AudioSource CarStart;

    // Private
    private GameObject[] _lights;
    private bool _isLightsOn;

    // Use this for initialization
    void Start()
    {
        _lights = GameObject.FindGameObjectsWithTag("Light");
        _isLightsOn = true;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // need a variable to hold the location of our Raycast look
        RaycastHit look;

        //if raycast hits an object then do somthing....
        if (Physics.Raycast(this.PlayerDirection.position, this.PlayerDirection.forward, out look, 5f))
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
            else if (look.transform.gameObject.CompareTag("Car") || look.transform.gameObject.CompareTag("Enemy") || look.transform.gameObject.CompareTag("Player'sCar"))
            {
                DisplayText.gameObject.SetActive(true);
                DisplayText.text = "Try to open car";
            }
        }
        else
        {
            DisplayText.gameObject.SetActive(false);
            DisplayText.text = "";
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
                    CarStart.Play();
                    look.transform.SendMessage("Follow");
                }
                else if (look.transform.gameObject.CompareTag("Car"))
                {
                    CarAttempt.Play();
                }
                else if (look.transform.gameObject.CompareTag("Bench"))
                {
                    Sit.Play();
                    DisplayText.gameObject.SetActive(false);
                    DisplayText.text = "";
                }
                else if (look.transform.gameObject.CompareTag("Player'sCar"))
                {
                    GetinCar.Play();
                    StartCoroutine(_moveToLevel3(new WaitForSeconds(5f)));
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boarder") || other.gameObject.CompareTag("Enemy"))
        {
            PlayerDirection.position = Respawn.position;
        }
    }
    private IEnumerator _moveToLevel3(WaitForSeconds _waitTime)
    {
        yield return _waitTime;
        SceneManager.LoadScene("Level3");
    }
}
