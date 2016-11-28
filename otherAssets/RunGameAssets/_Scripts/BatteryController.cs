using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BatteryController : MonoBehaviour
{
    //PRIVATE INSTANCE VARIABLES
    private GameObject _gameControllerObject;
    private GameController _gameController;

    // Use this for initialization
    void Start()
    {
        this._gameControllerObject = GameObject.Find("Game Controller");
        this._gameController = this._gameControllerObject.GetComponent<GameController>() as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        Rotated();
    }

    private void Rotated()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        _gameController.FillAmount = 1f;
    }
}
