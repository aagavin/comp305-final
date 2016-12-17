using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    private Transform key;
    private Transform player;

	// Use this for initialization
	void Start () {
        
        key = GameObject.FindGameObjectWithTag("KeyObject").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!key)
            Debug.Log("ERROR could not find Key!");
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("Rotator", 1f);
        
    }
    
    void Rotation()
    {
        Vector2 target = key.position;

        float dx = player.position.x - target.x;
        float dy = player.position.y - target.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));

        this.transform.rotation = rot;

    }

    IEnumerator Rotator()
        {
        yield return new WaitForSeconds(1f);
        Rotation();
        Debug.Log("boo");
    }

    

}
