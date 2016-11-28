using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameWonController : MonoBehaviour {
    //PUBLIC
    public Text GameWonScore;

	// Use this for initialization
	void Start () {
        GameWonScore.text = "Score: " + PlayerPrefs.GetFloat("Score");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
