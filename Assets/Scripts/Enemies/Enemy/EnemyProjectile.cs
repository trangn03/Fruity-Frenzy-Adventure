using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] public float speed;
    [SerializeField] public float resetTime; 
    public float lifeTime;
    public Animator animator;
    public BoxCollider2D collide;
    public bool hit; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //collide = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) {
            return;
        }
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void ActivateProjectile()
    {
        //hit = false; 
        lifeTime = 0;
        gameObject.SetActive(true);
        //collide.enabled = true;
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }
}
