using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdAnimation : MonoBehaviour
{
    private Animator anim;
    private MovingWithWaitTime blueBirdMoving;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private SpriteRenderer sprite;
    private int currentWaypointIndex = 0;
    private bool isAttack = false;
    private bool isDeath = false;
    private string currentState = "BlueBird";

    private void Start()
    {
        blueBirdMoving = GetComponent<MovingWithWaitTime>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
        currentWaypointIndex = blueBirdMoving.GetCurrentWaypointIndex();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaypointIndex = blueBirdMoving.GetCurrentWaypointIndex();
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        if (currentWaypointIndex == 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isDeath)
        {
            ChangeAnimationState("BlueBird_Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("BlueBird_Hit");
        }
        else
        {
            ChangeAnimationState("BlueBird");
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