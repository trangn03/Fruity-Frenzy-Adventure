// Script referenced from https://discussions.unity.com/t/make-music-continue-playing-through-scenes/175434/6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public static AudioControl backgroundMusic;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Begin Scene" || SceneManager.GetActiveScene().name == "Game Over" || SceneManager.GetActiveScene().name == "End Scene") {
            AudioControl.backgroundMusic.GetComponent<AudioSource>().Pause();
        }
    }
    
    public void Awake() {
        if (backgroundMusic == null) {
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

    }

    public void playMusic() {
        AudioControl.backgroundMusic.GetComponent<AudioSource>().UnPause();
    }

    public void stopMusic() {
        AudioControl.backgroundMusic.GetComponent<AudioSource>().Pause();
    }
}
