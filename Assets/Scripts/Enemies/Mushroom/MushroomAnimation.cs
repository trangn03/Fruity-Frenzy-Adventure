using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimation : MonoBehaviour
{
    private Animator anim;
    private MovingWithWaitTime movingWithWaitTime;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private SpriteRenderer sprite;
    private int currentWaypointIndex = 0;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isWaiting = false;
    private string currentState = "Mushroom_Run";

    private void Start()
    {
        movingWithWaitTime = GetComponent<MovingWithWaitTime>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
        currentWaypointIndex = movingWithWaitTime.GetCurrentWaypointIndex();
        isWaiting = movingWithWaitTime.GetIsWaiting();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaypointIndex = movingWithWaitTime.GetCurrentWaypointIndex();
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isWaiting = movingWithWaitTime.GetIsWaiting();

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
            ChangeAnimationState("Mushroom_Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("Mushroom_Hit");
        }
        else if (isWaiting)
        {
            ChangeAnimationState("Mushroom_Idle");
        }
        else
        {
            ChangeAnimationState("Mushroom_Run");
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