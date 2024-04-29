using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask jumponGround;
    [SerializeField] public AudioSource jumpSound;
    private float dirX;
    private float jumps = 0;
    private bool isDoubleJump = false;
    [SerializeField] private const int maxJumps = 2;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
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

    private void Move() {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        Flip();
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
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

    private void Flip() {
        if (dirX < 0 ) {
            sprite.flipX = true;
        }
        else if (dirX > 0) {
            sprite.flipX = false;
        }
    }
    
    private bool ontheGround() {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumponGround);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, 1.2f * jumpForce);
            
        }
    }
}
