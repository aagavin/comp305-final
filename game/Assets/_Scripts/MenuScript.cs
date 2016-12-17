using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
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

/// <summary>
/// Used for switching the menu scene to other levels
/// </summary>
public class MenuScript : MonoBehaviour {
	// PUBLIC VARIABLES
	public Button Button;
	/************** PUBLIC FUNCTIONS **************/

	/// <summary>
	/// Goto Level 1 Scene
	/// </summary>
	public void level1button_Click()
	{
		SceneManager.LoadScene("Level1");
	}



	/// <summary>
	/// Goto Level 2 Scene
	/// </summary>
	public void level2button_Click()
	{
		SceneManager.LoadScene("Level2");
	}

	/// <summary>
	/// Goto Level 3 Scene
	/// </summary>
	public void level3button_Click()
	{
		SceneManager.LoadScene("Level3");
	}

	/// <summary>
	/// Goto Instructions scene
	/// </summary>
	public void instruction_Click()
	{
		SceneManager.LoadScene("Instructions");
	}


	/// <summary>
	/// Goto menu Scene
	/// </summary>
	public void exit_Click()
	{
		SceneManager.LoadScene("Menu");
	}

	/// <summary>
	/// Level1to2buttons the click.
	/// </summary>
	public void level1to2button_Click()
	{
		SceneManager.LoadScene("Level1toLevel2");
	}

	/// <summary>
	/// Level2to3buttons the click.
	/// </summary>
	public void level2to3button_Click()
	{
		SceneManager.LoadScene("Level2toLevel3");
	}

	/// <summary>
	/// Games the over button click.
	/// </summary>
	public void gameOverButton_Click()
	{
		SceneManager.LoadScene("GameOver");
	}


	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		//cheat for going to level various levels
		if (Input.GetKeyDown ("1")) {
			this.level1button_Click ();
		} else if (Input.GetKeyDown ("2")) {
			this.level2button_Click ();
		} else if (Input.GetKeyDown ("3")) {
			this.level3button_Click ();
		}




	}
}