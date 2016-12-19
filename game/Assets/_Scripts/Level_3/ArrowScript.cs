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

	private GameObject key;
    private GameObject player;

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
    }
    
    void Rotation()
    {
		//Couldn't fix this <(T_T)>^(T_T)^<(T_T)>

        float dx = player.transform.position.x - key.transform.position.x;
        float dy = player.transform.position.y - key.transform.position.y;
		float dz = player.transform.position.z - key.transform.position.z;

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
        Debug.Log("searching for key");
		yield return new WaitForSeconds(5f);
		Debug.Log (GameObject.Find("WinObject"));
        key = GameObject.Find("WinObject");

        player = GameObject.Find("FPSController");
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
