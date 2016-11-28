using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MiniMapScript : MonoBehaviour {

    public bool m_IsWalking;
    public Animator animator;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Read input
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        if (horizontal !=0 || vertical != 0)
        {
            this.animator.SetInteger("PlayerState", 1);
        }

        else
        {
            this.animator.SetInteger("PlayerState", 0);
        }
    }
}
