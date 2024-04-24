using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RockHead : MonoBehaviour
{
    public Vector3 destination;
    [SerializeField] public float speed;
    [SerializeField] public float range;
    [SerializeField] public float checkDelay;
    [SerializeField] public LayerMask playerLayer;
    public bool attacking; 
    public float checkTimer;
    public Vector3[] directions = new Vector3[4];
    [SerializeField] public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking) {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay) {
                checkPlayer();
            }
        }
    }

    public void checkPlayer() {
        calculateDirection();

        for (int i = 0; i < directions.Length; i++) {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer); 
            if (hit.collider != null && !attacking) {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    public void calculateDirection() {
        directions[0] = transform.right * range; 
        directions[1] = -transform.right * range; // left
        directions[2] = transform.up * range; // up
        directions[3] = -transform.up * range; // down
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.gameObject.GetComponent<PlayerLife>().TakeLife(damage);
        }
        Stop(); 
    }

    public void Stop() {
        destination = transform.position;
        attacking = false;
    }

    public void OnEnable() {
        Stop();
    }
}

