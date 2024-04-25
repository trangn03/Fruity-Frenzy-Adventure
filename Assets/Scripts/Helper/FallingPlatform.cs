using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] public float fallDelay = 1f;
    [SerializeField] public float destroyDelay = 2f;
    [SerializeField] public float restartDelay = 5f;
    private Vector2 originalPosition;
    private Animator anim;
    private string currentState = "FallingFlatform";
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        originalPosition = transform.position;
        anim = GetComponent<Animator>();
        ChangeAnimationState("FallingFlatform");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        ChangeAnimationState("FallingFlatform_Off");
        yield return new WaitForSeconds(destroyDelay);
        gameObject.SetActive(false);
        Invoke("Restart", restartDelay);
    }

    private void Restart()
    {
        gameObject.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = originalPosition;
        ChangeAnimationState("FallingFlatform");
    }

    private void ChangeAnimationState(string newState)
    {
        if (anim == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(newState))
        {
            return;
        }

        if (!anim.HasState(0, Animator.StringToHash(newState)))
        {
            return;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(newState))
        {
            return;
        }

        currentState = newState;
        anim.Play(currentState);
    }
}