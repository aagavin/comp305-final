using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    private Transform key;

	// Use this for initialization
	void Start () {

        key = GameObject.FindGameObjectWithTag("KeyObject").transform;
        if (!key)
            Debug.Log("ERROR could not find Key!");
    }
	
	// Update is called once per frame
	void Update () {
        Rotation();
    }

    void Rotation()
    {
        Vector2 target = key.position;

        float dx = this.transform.position.x - target.x;
        float dy = this.transform.position.y - target.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle - 5));

        this.transform.rotation = rot;
    }
}
