﻿using System;
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
    private Transform _player;
    private Vector3 _backtospot;
    private Quaternion _backtorotation;
    private bool _followplayer;
    private MeshCollider _collider;


    // Use this for initialization
    void Start()
    {
        this._player = GameObject.FindWithTag("Player").transform;
        Headlight.enabled = false;
        FollowPlayer = false;
        _collider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayer)
        {
            this.Agent.SetDestination(this._player.position);
        }
    }

    public void Follow()
    {
        this._backtospot = this.gameObject.transform.position;
        this._backtorotation = this.gameObject.transform.rotation;
        this.Headlight.enabled = true;
        this.FollowPlayer = true;
        this._collider.convex = true;
        this._collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.Headlight.enabled = false;
            this.FollowPlayer = false;
            this._collider.isTrigger = false;
            this._collider.convex = false;
            this.gameObject.transform.position = this._backtospot;
            this.gameObject.transform.rotation = this._backtorotation;
        }
    }
}
