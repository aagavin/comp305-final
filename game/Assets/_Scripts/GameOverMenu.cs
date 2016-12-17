using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour {

    public Text Score_Text;
	// Use this for initialization
	void Start () {
        int _score = PlayerPrefs.GetInt("HighScore");
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
