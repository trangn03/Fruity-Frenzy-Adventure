using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicGameOverScript : MonoBehaviour
{
    public AudioSource gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void restartGame() {
        SceneManager.LoadScene("Level 1");
    }

    public void backtoMenu() {
        SceneManager.LoadScene("Begin Scene");
    }
    
    public void quitGame() {
        Application.Quit();
    }  
}
