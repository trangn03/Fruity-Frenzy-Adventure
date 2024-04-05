using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] public AudioSource deathSound;
    public Text lifeText;
    public int maxLife = 3;
    public int currentLife;
    [SerializeField] public float fallThreshold;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        UpdateLife();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= fallThreshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap")) {
            TakeLife(1);
            deathSound.Play();
        }
    }

    public void TakeLife(int life) {
        currentLife -= life;
        UpdateLife();
        if (currentLife == 0) {
            Die();
        }
    }

    public void UpdateLife() {
        lifeText.text = currentLife.ToString();
    }

    public void Die() {
        SceneManager.LoadScene("Game Over");
    }
}
