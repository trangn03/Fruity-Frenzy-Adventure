using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbSlide : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    private bool isTouchingWall;
    private bool isTouchGrounded;
    private bool jumpOff = false;
    private BoxCollider2D boxCollider;
    [SerializeField] private float wallSlideSpeed = 2f;
    [SerializeField] private float wallClimbSpeed = 6f;
    private Rigidbody2D rb;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask wallLayer;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isTouchingWall) {
            rb.gravityScale = 1f;
        }

        isTouchGrounded = isGrounded();
        if (!isTouchGrounded) {
            if (Physics2D.Raycast(transform.position, transform.right, wallCheckDistance, wallLayer)) {
                isTouchingWall = true;
            }
            else if (Physics2D.Raycast(transform.position, -transform.right, wallCheckDistance, wallLayer)) {
                isTouchingWall = true;
            }
            else {
                isTouchingWall = false;
            }
        }
        else {
            isTouchingWall = false;
        }
        wallClimb(isTouchingWall, isTouchGrounded);
    }

    private void wallClimb(bool isTouchingWall, bool isTouchGrounded) {
        if (isTouchGrounded) {
            jumpOff = false;
            return;
        }

        if (isTouchingWall) {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                rb.velocity = new Vector2(rb.velocity.x, wallClimbSpeed);
                rb.gravityScale = 0f;
                jumpOff = true;
            }
            else {
                wallSlide();
                jumpOff = false;
            }
            return;
        }

        if (jumpOff) {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
            rb.gravityScale = 1f;
            jumpOff = false;
            return;
        }
    }

    private void wallSlide() {
        rb.gravityScale = 1f;
        rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    public bool GetIsTouchingWall() {
        return this.isTouchingWall;
    }
}
