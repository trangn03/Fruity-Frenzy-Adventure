using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicDuringGame : MonoBehaviour
{
    public bool GameActive = false;
    // Start is called before the first frame update
    void Start()
    {
        playGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame() {
        Time.timeScale = 1f;
        GameActive = true;
    }

    public void pauseGame() {
        Time.timeScale = 0f;
        GameActive = false;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
