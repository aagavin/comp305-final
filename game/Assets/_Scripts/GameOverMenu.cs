using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
* Pedro Bento
* Aaron Fernandes
* Waynell Lovell
* Ashley Tjonhing
* 
* 
* COMP 305 - Assignment 4 | Final 
*/

public class GameOverMenu : MonoBehaviour {

    public Text Score_Text;
	// Use this for initialization
	void Start () {
        //__++++++++++ THIS IS A CRASH 
        int _score = PlayerPrefs.GetInt("Score");
		Debug.Log ("Score:");
		Debug.Log (PlayerPrefs.GetInt ("Score"));
		Score_Text.text += _score;
		this._resetGame (_score);
	}
	
	/// <summary>
	/// Reset this instance.
	/// </summary>
	public void _resetGame(int score){
		int highScore = PlayerPrefs.GetInt ("HighScore");
		if (score > highScore) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}
}
