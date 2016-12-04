using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startbutton_Click()
    {
        SceneManager.LoadScene("Level1");
    }

    public void instruction_Click()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void exit_Click()
    {
        SceneManager.LoadScene("Menu");
    }
}
