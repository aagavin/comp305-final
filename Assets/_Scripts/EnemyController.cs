using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    //Public Instance Variables
    public NavMeshAgent agent;
    public float turnSpeed = 5.0f;
    public float speed = 5.0f;

    //Private Instance Variables
    private Transform player;
    private Transform _transform;
    private Rigidbody _rigidbody;

    // Use this for initialization
    void Start () {
        this.player = GameObject.FindWithTag("Player").transform;
        this._transform = GetComponent<Transform>();
        this._rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            //Find player position in relation to enemy
            Vector3 _dir = new Vector3(player.position.x, player.position.y, player.position.z) - this._rigidbody.position;
            _dir.Normalize();
            //Quaternion pos = Quaternion.Euler(270, transform.rotation.y, transform.rotation.z);
            //turn enemy to look at player
            transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.LookRotation(_dir), turnSpeed * Time.deltaTime);
            //move towards player
            this.agent.SetDestination(this.player.position);
        }

        //Keep model off the ground
        _transform.position = new Vector3(_transform.position.x, 8f, _transform.position.z);

    }

}
