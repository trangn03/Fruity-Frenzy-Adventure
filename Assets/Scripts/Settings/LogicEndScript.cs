using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicEndScript : MonoBehaviour
{
    public AudioSource end;
    // Start is called before the first frame update
    void Start()
    {
        end.Play();
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
