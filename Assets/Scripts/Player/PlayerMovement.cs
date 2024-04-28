using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    [SerializeField] public LayerMask jumponGround;
    [SerializeField] public AudioSource jumpSound;
    [SerializeField] public float up;
    [SerializeField] public float down;
    private float dirX;
    private float jumps = 0;
    private bool isDoubleJump = false;
    [SerializeField] public const int maxJumps = 2;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float jumpForce = 7f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ontheGround() || rb.velocity.y < -0.01f)
        {
            isDoubleJump = false; 
        }

        Move();
        Jump();
    }

    public bool GetIsDoubleJump()
    {
        return this.isDoubleJump;
    }

    public void Move() {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        Flip();
    }

    public void Jump() {
        if (Input.GetButtonDown("Jump")) {
            if (ontheGround()) {
                jumpSound.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumps = 1; 
                isDoubleJump = false;
            }
            else if (jumps < maxJumps) {
                jumpSound.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumps++;
                isDoubleJump = true;
            }
        }
    }

    public void Flip() {
        if (dirX < 0 ) {
            sprite.flipX = true;
        }
        else if (dirX > 0) {
            sprite.flipX = false;
        }
    }
    

    public bool ontheGround() {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumponGround);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumps * 1.7f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Up"))
        {
            transform.localScale *= up;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Down"))
        {
            transform.localScale *= down;
            Destroy(collision.gameObject);
        }
    }
}
