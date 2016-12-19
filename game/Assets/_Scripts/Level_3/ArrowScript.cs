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

	private GameObject target;
    private GameObject player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("KeyObject") != null)
        {
            Debug.Log("Key Exists.");
            Rotation();
        }

        else
        {
            Debug.Log("Key Not Found.");
        }


    }
    
    void Rotation()
    {
        //Couldn't fix this <(T_T)>^(T_T)^<(T_T)>
        player = GameObject.Find("FPSController");
        target = GameObject.FindGameObjectWithTag("KeyObject");

        Vector3 ToTarget = target.transform.position - player.transform.position;
        float angle = (Mathf.Atan2(ToTarget.y, ToTarget.x) * Mathf.Rad2Deg)-90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q, Time.deltaTime * 1f);

    }
}
