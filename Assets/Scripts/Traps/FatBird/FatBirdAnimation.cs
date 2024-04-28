using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FatBirdAnimation : MonoBehaviour
{
    private Animator anim;
    private FatBirdMoving fatBirdMoving;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isGrounded = false;
    private string currentState = "FatBird";
    private Rigidbody2D rb;

    private void Start()
    {
        fatBirdMoving = GetComponent<FatBirdMoving>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isGrounded = fatBirdMoving.GetIsGrounded();
        rb = GetComponent<Rigidbody2D>();

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isDeath)
        {
            ChangeAnimationState("FatBird_Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("FatBird_Hit");
        }
        else if (isGrounded)
        {
            ChangeAnimationState("FatBird_Ground");
        }
        else if (rb.gravityScale != 0f)
        {
            ChangeAnimationState("FatBird_Fall");
        }
        else
        {
            ChangeAnimationState("FatBird");
        }
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