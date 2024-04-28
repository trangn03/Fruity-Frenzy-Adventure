using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAnimation : MonoBehaviour
{
    private Animator anim;
    private CollisionDetection collisionDetection;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isTouch = false;
    private string currentState = "Bee";

    private void Start()
    {
        killPointAndAttackPlayer = this.transform.GetChild(0).GetComponent<KillPointAndAttackPlayer>();
        collisionDetection = this.transform.GetChild(1).GetComponent<CollisionDetection>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isTouch = collisionDetection.GetIsTouch();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isDeath)
        {
            ChangeAnimationState("Bee_Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("Bee_Hit");
        }
        else if (isTouch)
        {
            ChangeAnimationState("Bee_Attack");
        }else
        {
            ChangeAnimationState("Bee");
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