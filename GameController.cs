using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for scene reload we need an extra import declaration 
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // this script will show the game over message 
    // manage the score 
    //restart the level and generally keep track of the game 

    public bool gameOver = false;
    // we have to set the control of the game to be decided by this variable 

    public static GameController instance;
    // we have made an instance of a class and we will make it accessable from outside the script as well 

    public GameObject gameOverText;
  
    void Awake()
    {
        // if there is no instance of a game controller already running then
        // this is the correct instance
        if (instance == null)
        {
            instance = this;
        }
        // if this aint the current instance then destory the gmae object 
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // this is a very convinet way to access things between scripts 

    }

    // Update is called once per frame
    void Update()
    {
       if (gameOver= true && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // this means that if the game is over and you get an input from the mouse then reload the current scene 

        }
    }
    public void BirdDied() {
        {
            gameOverText.SetActive (true);
            gameOver = true;
        } 
    }
}
