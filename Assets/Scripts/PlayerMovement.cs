using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;

    public float movingHori;
    [SerializeField] public float movingSpeed;
    [SerializeField] public float jumping;
    private enum MovementState {idle, running, jumping, falling};
    [SerializeField] public LayerMask jumponGround;
    [SerializeField] public AudioSource jumpSound;
    [SerializeField] public float up;
    [SerializeField] public float down;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationUpdate();
        
    }

    public void Movement() {
        movingHori = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(movingHori * movingSpeed, rigidBody.velocity.y);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && ontheGround()) {
            jumpSound.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumping);
        }
        
    }

    public void AnimationUpdate() {
        MovementState state;

        if (Mathf.Abs(movingHori) > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = movingHori < 0f;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigidBody.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rigidBody.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        Debug.Log("Current state: " + state.ToString());

        animator.SetInteger("state", (int)state);
    }

    public bool ontheGround() {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumponGround);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpSound.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumping * 1.7f);
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
