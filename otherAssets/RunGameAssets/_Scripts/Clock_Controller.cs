using UnityEngine;
using System.Collections;

public class Clock_Controller : MonoBehaviour {

    //PRIVATE
    private GameObject _gameControllerObject;
    private GameController _gameController;
    private GameObject _spawnPoint;
    private GameObject _player;
    private bool _goingup;
    private float _speed;
    private Transform _transform;

    // PUBLIC PROPERTIES+++++++++++++++++++++++++++++++++
    public float Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }



    // Use this for initialization
    void Start () {
        _goingup = true;
        this._transform = this.GetComponent<Transform>();
        this._speed = 0.01f;
        this._gameControllerObject = GameObject.Find("Game Controller");
        this._gameController = this._gameControllerObject.GetComponent<GameController> () as GameController;
        this._player = GameObject.Find("Player");
        this._spawnPoint = GameObject.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        _slowMovement();
    }
    //private methods
    private void _slowMovement()
    {
        Vector3 newPosition = this._transform.position;

        if (this._transform.position.y > 3.1f)
        {
            _goingup = false;
        }
        else if (this._transform.position.y < 1.43f)
        {
            _goingup = true;
        }

        if (_goingup)
        {
            newPosition.y += this._speed;
            this._transform.position = newPosition;
        }
        else
        {
            newPosition.y -= this._speed;
            this._transform.position = newPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _player.transform.position = _spawnPoint.transform.position;
        _player.transform.rotation = _spawnPoint.transform.rotation;
        _gameController.SpookLaugh.Play();
        Destroy(gameObject);
    }
}
