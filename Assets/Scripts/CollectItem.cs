using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public int kiwi = 0;
    public int kiwiGoal = 5;
    public bool hasReachCheckpoint = false;
    public Text kiwiText;
    [SerializeField]
    public AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Kiwi")) {
            collectSound.Play();
            Destroy(collision.gameObject);
            kiwi++;
            kiwiText.text = kiwi.ToString();
        }

        if (collision.gameObject.CompareTag("Checkpoint")) {
            hasReachCheckpoint = true;
            if (kiwi == kiwiGoal && hasReachCheckpoint) {
                NextLevel();
            }
            else {
                ReloadScene();
            }

        }
    }

    public void NextLevel() {
        SceneManager.LoadScene("Level 1");
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
