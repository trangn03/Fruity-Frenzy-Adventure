using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TurtleAnimation : MonoBehaviour
{
    private Animator anim;
    private TurtleBehaviour turtleBehaviour;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isSpikeOut = false;
    private bool isSpikeIn = true;
    private bool isSpikeInDone = false;
    private bool isSpikeOutDone = false;
    private string currentState = "Turtle";

    private void Start()
    {
        turtleBehaviour = GetComponent<TurtleBehaviour>();
        killPointAndAttackPlayer = this.transform.GetChild(0).GetComponent<KillPointAndAttackPlayer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isSpikeOut = turtleBehaviour.GetIsSpikeOut();
        isSpikeIn = turtleBehaviour.GetIsSpikeIn();
        isSpikeOutDone = turtleBehaviour.GetIsSpikeOutDone();
        isSpikeInDone = turtleBehaviour.GetIsSpikeInDone();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isDeath)
        {
            ChangeAnimationState("Turtle_Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("Turtle_Hit");
        }
        else if (isSpikeInDone)
        {
            ChangeAnimationState("Turtle");
        }
        else if (isSpikeIn)
        {
            ChangeAnimationState("Turtle_Spikesin");
        }
        else if (isSpikeOutDone)
        {
            ChangeAnimationState("Turtle_Idle1");
        }
        else if (isSpikeOut)
        {
            ChangeAnimationState("Turtle_Spikesout");
        }
        else
        {
            ChangeAnimationState("Turtle");
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