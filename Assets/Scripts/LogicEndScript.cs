using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicEndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
