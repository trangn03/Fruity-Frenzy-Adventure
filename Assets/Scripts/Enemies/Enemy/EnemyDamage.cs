using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected int damage;
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
            collision.gameObject.GetComponent<PlayerLife>().TakeLife(damage);
        }
    }
}
