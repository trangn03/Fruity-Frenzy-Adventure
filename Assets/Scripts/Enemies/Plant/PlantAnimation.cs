using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimation : MonoBehaviour
{
    private Animator anim;
    private CollisionDetection collisionDetection;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isTouch = false;
    private string currentState = "Plant_Idle";
    // Start is called before the first frame update
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
            ChangeAnimationState("Plant_Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("Plant_Hit");
        }
        else if (isTouch)
        {
            ChangeAnimationState("Plant_Attack");
        }
        else
        {
            ChangeAnimationState("Plant_Idle");
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

        if (currentState == newState)
        {
            return;
        }

        anim.Play(newState);
        currentState = newState;
    }
}
