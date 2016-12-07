using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //Public
    public NavMeshAgent Agent;
    public Light Headlight;
    public bool FollowPlayer
    {
        get
        {
            return this._followplayer;
        }
        set
        {
            this._followplayer = value;
        }
    }

    //private
    private Transform Player;
    private Transform _CurrentEnemy;
    private bool _followplayer;
    // Use this for initialization
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;
        this._CurrentEnemy = this.GetComponent<Transform>();
        Headlight.enabled = false;
        FollowPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayer)
        {
            this.Agent.SetDestination(this.Player.position);
        }
    }
}
