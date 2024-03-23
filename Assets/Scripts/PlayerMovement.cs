using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;

    private float movingHori;
    [SerializeField] 
    private float movingSpeed;
    [SerializeField] 
    private float jumping;
    private enum MovementState {idle, running, jumping, falling};
    [SerializeField]
    private LayerMask jumponGround;
    [SerializeField]
    public AudioSource jumpSound;

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

        Debug.Log("Current state: " + state.ToString()); // Debug log to check current state

        animator.SetInteger("state", (int)state);
    }

    public bool ontheGround() {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumponGround);
    }
}
