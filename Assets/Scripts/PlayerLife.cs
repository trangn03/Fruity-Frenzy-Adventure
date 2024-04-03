using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    [SerializeField] public AudioSource deathSound;
    public Text lifeText;
    public int maxLife = 3;
    public int currentLife;
    public GameObject iceParticlePrefab;
    public float spawnRate = 1f; // Rate of ice particle spawning
    public float spawnSpeed = 5f; // Speed of falling ice particles
    public float spawnDelay = 1f; // Delay before spawning starts after player enters trigger zone

    private bool playerInRange = false;
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentLife = maxLife;
        UpdateLife();
        nextSpawnTime = Time.time + spawnDelay; // Start spawning after the delay
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Time.time >= nextSpawnTime)
        {
            SpawnIceParticle();
            nextSpawnTime = Time.time + 1f / spawnRate; // Adjust spawn rate
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap")) {
            TakeLife(1);
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
        deathSound.Play();
        SceneManager.LoadScene("Game Over");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ice"))
        {
            playerInRange = false;
        }
    }

    private void SpawnIceParticle()
    {
        // Instantiate ice particle prefab with downward velocity
        GameObject iceParticle = Instantiate(iceParticlePrefab, transform.position, Quaternion.identity);
        Rigidbody2D iceRigidbody = iceParticle.GetComponent<Rigidbody2D>();
        if (iceRigidbody != null)
        {
            iceRigidbody.velocity = Vector2.down * spawnSpeed;
        }
    }
}
