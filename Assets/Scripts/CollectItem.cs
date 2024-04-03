using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public int item = 0;
    public int itemGoal = 5;
    public bool hasReachCheckpoint = false;
    public Text itemText;
    public AudioSource collectSound;
    public AudioSource finishSound;
    public bool isFinished = false;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();
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
            hasReachCheckpoint = true;
            if (item == itemGoal && hasReachCheckpoint) {
                Debug.Log("All items collected and checkpoint reached. Moving to next level.");
                NextLevel();
            }
            else {
                Debug.Log("Not enough items collected or checkpoint not reached. Reloading scene.");
                ReloadScene();
            }
        }

        if (collision.gameObject.CompareTag("Player")) {
            finishSound.Play();
            isFinished = true;
            Invoke("NextLevel", 1.5f); // This seems unnecessary as it will call NextLevel() again.
        }
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
