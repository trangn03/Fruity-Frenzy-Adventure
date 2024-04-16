using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public float speed;
    public bool hit; 
    public float direction;
    public BoxCollider2D collide;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) {
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        hit = true; 
        collide.enabled = false;
        animator.SetTrigger("Explode");
    }

    public void setDirection(float _direction) {
        direction = _direction; 
        gameObject.SetActive(true);
        hit = false;
        collide.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction) {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void disableProjectile() {
        gameObject.SetActive(false);
    }
    
}
