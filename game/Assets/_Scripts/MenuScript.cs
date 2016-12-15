using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
}
