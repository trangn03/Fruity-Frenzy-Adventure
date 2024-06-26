using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class BeginGame : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene("Level 1");
    }

    public void instructionsGame() {
        SceneManager.LoadScene("Instructions");
    }

    public void settingsGame() {
        SceneManager.LoadScene("Settings");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void soundOn() {
        sound.Play();
    }

    public void soundOff() {
        sound.Stop();
    }
}
