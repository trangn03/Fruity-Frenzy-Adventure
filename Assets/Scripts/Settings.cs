using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backtoMenu() {
        SceneManager.LoadScene("Begin Scene");
    }

    public void playGame() {
        SceneManager.LoadScene("Level 1");
    }
}
