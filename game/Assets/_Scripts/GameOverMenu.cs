using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour {

    public Text Score_Text;
	// Use this for initialization
	void Start () {
        int HighScore = PlayerPrefs.GetInt("HighScore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
