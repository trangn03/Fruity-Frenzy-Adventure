using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private Animator anim;
    private AreaEffector2D areaEffector2D;
    private string currentState = "Fan";

    private void Start()
    {
        anim = GetComponent<Animator>();
        areaEffector2D = gameObject.GetComponent<AreaEffector2D>();
        ChangeAnimationState("Fan");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            On();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Off();
        }
    }

    private void On()
    {
        ChangeAnimationState("Fan_On");
        areaEffector2D.enabled = true;
    }

    private void Off()
    {
        ChangeAnimationState("Fan");
        areaEffector2D.enabled = false;
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
