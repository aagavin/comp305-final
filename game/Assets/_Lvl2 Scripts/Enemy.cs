using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //Public
    public NavMeshAgent Agent;
    public GameObject Body;
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
    private Transform _player;
    private Vector3 _backtospot;
    private Quaternion _backtorotation;
    private bool _followplayer;
    private MeshCollider _collider;


    // Use this for initialization
    void Start()
    {
        this._player = GameObject.FindWithTag("Player").transform;
        FollowPlayer = false;
        _collider = GetComponent<MeshCollider>();
        this._backtospot = this.Body.transform.position;
        this._backtorotation = this.Body.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayer)
        {
            this.Agent.SetDestination(this._player.position);
        }
        else
        {
            this.Body.transform.position = this._backtospot;
            this.Body.transform.rotation = this._backtorotation;
        }
    }

    public void Follow()
    {
        this.FollowPlayer = true;
        this._collider.convex = true;
        this._collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
            this.FollowPlayer = false;
            this._collider.isTrigger = false;
            this._collider.convex = false;
    }
}
