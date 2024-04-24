using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicDuringGame : MonoBehaviour
{
    public bool GameActive = false;
    public AudioControl music;
    // Start is called before the first frame update
    void Start()
    {
        playGame();
        music = FindObjectOfType<AudioControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Begin Scene");
        }

    }

    public void playGame() {
        Time.timeScale = 1f;
        music.playMusic();
        GameActive = true;
    }

    public void pauseGame() {
        Time.timeScale = 0f;
        music.stopMusic();
        GameActive = false;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
