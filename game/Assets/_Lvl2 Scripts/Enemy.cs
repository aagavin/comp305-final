using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //Public
    public NavMeshAgent Agent;
    public Light Headlight;

    //private
    private Transform Player;
    private Transform _CurrentEnemy;

    // Use this for initialization
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;
        this._CurrentEnemy = this.GetComponent<Transform>();
        Headlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
                //this.Agent.SetDestination(this.Player.position);
    }
}
