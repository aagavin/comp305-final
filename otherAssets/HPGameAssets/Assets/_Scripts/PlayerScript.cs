using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {

    //Private Instance Variables
    private int _livesValue = 100;
    private int score = 0;

    //Public Instance Variables
    [Header("Labels")]
    public Text livesLabel;
    public Text scoreLabel;
    public Text gameOverLabel;
    public Text finalLabel;
    public Text victory;
    public Button restartButton;

    [Header("Game Objects")]
    public GameObject Dementor;
    public GameObject Beans;
    public GameObject Player;
    public GameObject tree1;
    public GameObject tree2;

    [Header("Music")]
    public AudioSource endMusic;
    public AudioSource backgroundMusic;


    [Header("Sounds")]
    public AudioSource beans;
    public AudioSource dementor;

    //Public Properties

    public int scoreValue // updates score
    {
        get { return this.score; }
        set
        {
            this.score = value;
            this.scoreLabel.text = "Score: " + this.score;
        }
    }

    public int livesValue //updates lives
    {
        get { return this._livesValue; }
        set
        {
            this._livesValue = value;
            this.livesLabel.text = "Health: " + this._livesValue;
        }
    }

    // Use this for initialization
    void Start()
    {
        backgroundMusic.Play();
        backgroundMusic.loop = true;
        gameOverLabel.gameObject.SetActive(false);
        finalLabel.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider otherGameObject)
    {
        if (otherGameObject.CompareTag("Beans")) 
        {
            otherGameObject.gameObject.SetActive(false);
            this.scoreValue += 10;
            beans.Play();
        }

        if (otherGameObject.gameObject.name == "Tree") //cheat to transport to other tree
        {
            transform.position = new Vector3(tree2.gameObject.transform.position.x, tree2.gameObject.transform.position.y + 5, tree2.gameObject.transform.position.z - 3);
        }

        if (otherGameObject.gameObject.name == "Tree 1")//cheat to transport back to other tree, but on the top of the maze
        {
            transform.position = new Vector3(tree1.gameObject.transform.position.x, tree1.gameObject.transform.position.y + 5, tree1.gameObject.transform.position.z - 3);
        }

        if (otherGameObject.CompareTag("Enemy")) 
        {
            this.livesValue -= 5;
            dementor.Play();

            if (livesValue <= 0)
            {
                backgroundMusic.Stop();
                backgroundMusic.loop = false;
                endGame();
            }

        }
    }

    public void endGame()
    {
        this.scoreLabel.gameObject.SetActive(false);
        this.livesLabel.gameObject.SetActive(false);
        this.gameOverLabel.gameObject.SetActive(true);
        this.finalLabel.gameObject.SetActive(true);
        this.finalLabel.text = "Score: " + this.score;
        this.restartButton.gameObject.SetActive(true);
        this.Dementor.SetActive(false);
        this.Beans.SetActive(false);
        this.Player.SetActive(false);
        endMusic.Play();
        endMusic.loop = true;
    }

    public void restart_click()
    {
        SceneManager.LoadScene("Main");
    }
}
