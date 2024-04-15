using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class BeginGame : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] Slider volume;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            loadVolume();
        }
        else {
            loadVolume();
        }
        
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

    public void changeVolume() {
        AudioListener.volume = volume.value;
        saveVolume();
    }

    private void loadVolume() {
        volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void saveVolume() {
        PlayerPrefs.SetFloat("musicVolume", volume.value);
    }
}
