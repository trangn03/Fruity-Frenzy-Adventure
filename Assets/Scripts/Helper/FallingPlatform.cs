using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject container;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpringJoint2D springJoint;

    [SerializeField] private float fallDelay = 2.5f;
    [SerializeField] private float destroyDelay = 3f;

    private static readonly int fallingAnim = Animator.StringToHash("Falling");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();

        if (springJoint == null)
            springJoint = GetComponent<SpringJoint2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            springJoint.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            Invoke(nameof(Fall), fallDelay);
        }
    }

    private void Fall()
    {
        springJoint.enabled = false;
        animator.SetTrigger(fallingAnim);

        Destroy(container, destroyDelay);
    }
}
