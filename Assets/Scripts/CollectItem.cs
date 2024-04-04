using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public int item = 0;
    public int itemGoal = 5;
    public Text itemText;
    public AudioSource collectSound;
    public AudioSource finishSound;
    public bool isFinished = false;

    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Item")) {
            collectSound.Play();
            Destroy(collision.gameObject);
            item++;
            itemText.text = item.ToString();
            Debug.Log("Item collected. Total items: " + item);
        }

        if (collision.gameObject.CompareTag("Checkpoint")) {
            finishSound.Play();
            if (item >= itemGoal) {
                Invoke("NextLevel", 1f);
            }
            else {
                ReloadScene();
            }
        }

        if (collision.gameObject.CompareTag("End Game")) {
            if (item >= itemGoal) {
                SceneManager.LoadScene("End Scene");
            }
            else {
                ReloadScene();
            }
        }
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
