using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Pedro Bento
 * Aaron Fernandes
 * Waynell Lovell
 * Ashley Tjonhing
 * 
 * 
 * COMP 305 - Assignment 4 | Final 
 */ 


/// <summary>
/// Arrow script class
/// </summary>
public class ArrowScript : MonoBehaviour {

	private Vector3 key;
    private Transform player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
        
		StartCoroutine ("Starter");
    }
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		Rotation();
    }
    
    void Rotation()
    {
		//Couldn't fix this <(T_T)>^(T_T)^<(T_T)>
        Vector3 target = key;

        float dx = player.position.x - target.x;
        float dy = player.position.y - target.y;
		float dz = player.position.z - target.z;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(0, 0, angle);
		Debug.Log(angle);

        this.transform.rotation = rot;

    }

	/// <summary>
	/// Starter IEnumerator
	/// </summary>
	IEnumerator Starter()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log (GameObject.FindGameObjectWithTag ("KeyObject"));
		key = GameObject.FindGameObjectWithTag("KeyObject").transform.position;

		player = GameObject.FindGameObjectWithTag("Player").transform;
		/*
		if (!key) {
			Debug.Log ("ERROR could not find Key!");
		}
		*/
	}


	/// <summary>
	/// Rotator this instance.
	/// </summary>
    IEnumerator Rotator()
    {
        yield return new WaitForSeconds(5f);
        Rotation();
        Debug.Log("boo");
    }

    

}
