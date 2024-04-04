using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerLife : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    [SerializeField] public AudioSource deathSound;
    public Text lifeText;
    public int maxLife = 3;
    public int currentLife;
    [SerializeField] public float fallThreshold;
    public float fanForce = 1f;
    public float fanRestart = 1f;
    public GameObject iceParticle;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
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
