using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    [SerializeField]
    public AudioSource deathSound;
    public Text lifeText;
    public int maxLife = 3;
    public int currentLife;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap")) {
            TakeLife(1);
        }
        else if (collision.gameObject.CompareTag("Heart")) {
            AddLife(1);
            Destroy(collision.gameObject);
        }
    }

    public void TakeLife(int life) {
        currentLife -= life;
        UpdateLife();
        if (currentLife <= 0) {
            Die();
        }
    }

    public void AddLife(int life) {
        currentLife += life;
        UpdateLife();
    }

    public void UpdateLife() {
        lifeText.text = currentLife.ToString();
    }

    public void Die() {
        deathSound.Play();
        rigidBody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        SceneManager.LoadScene("Game Over");
    }
}
