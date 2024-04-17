using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] protected int life;
    public AudioSource collectheartSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.gameObject.GetComponent<PlayerLife>().GainLife(life);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Heart")) {
            collectheartSound.Play();
        }
    }
}
