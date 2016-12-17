using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBox : MonoBehaviour
{

    public GameController2 gameController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameController.HasKey)
            {
                gameController.Win();
            }
            else
            {
                //add instructions to find key and return to door?
            }
            
        }
    }
}
