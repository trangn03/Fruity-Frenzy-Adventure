using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isDead = false; 
    private bool isAppear;
    private WallClimbSlide wallClimbSlide;
    private PlayerMovement playerMovement;
    private int currentCharacter = 0;
    private enum AllCharacterState { Player_Appear, Player_Death }
    private ArrayList characterState = new ArrayList();
    private string currentState; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        wallClimbSlide = GetComponent<WallClimbSlide>();
        playerMovement = GetComponent<PlayerMovement>();
        currentCharacter = PlayerPrefs.GetInt("characterIndex");
        addCharacterState();
        currentState = ((string[])characterState[0])[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isAppear) {
            Appear();
        }
        else {
            UpdateAnimationState();
        }
    }

    private void Appear() {
        rb.bodyType = RigidbodyType2D.Static;
        ChangeAnimationState(AllCharacterState.Player_Appear.ToString());
    }

    private void updateAppear() {
        rb.bodyType = RigidbodyType2D.Dynamic;
        isAppear = false;
    }

    private void addCharacterState () {
        string[] pinkMan = new string[] {
            "Player_Idle", "Player_Falling", "Player_Jumping", "Player_Running", "Player_WallJump", "Player_DoubleJump",
        };
        characterState.Add(pinkMan);

        string[] maskDude = new string[] {
            "MaskDude_Idle", "MaskDude_Falling", "MaskDude_Jumping", "MaskDude_Running", "MaskDude_WallJump", "MaskDude_DoubleJump",
        };
        characterState.Add(maskDude);

        string[] ninjaFrog = new string[] {
            "NinjaFrog_Idle", "NinjaFrog_Falling", "NinjaFrog_Jumping", "NinjaFrog_Running", "NinjaFrog_WallJump", "NinjaFrog_DoubleJump",
        };
        characterState.Add(ninjaFrog);

        string[] virtualGuy = new string[] {
            "VirtualGuy_Idle", "VirtualGuy_Falling", "VirtualGuy_Jumping", "VirtualGuy_Running", "VirtualGuy_WallJump", "VirtualGuy_DoubleJump",
        };
        characterState.Add(virtualGuy);

    }

    public void setDead(bool value) {
        isDead = value; 
    }

    private void UpdateAnimationState()
    {
        if (isAppear) {
            ChangeAnimationState(AllCharacterState.Player_Appear.ToString());
            isAppear = false;
        }
        else if (isDead) {
            ChangeAnimationState(AllCharacterState.Player_Death.ToString());
        }
        else if (wallClimbSlide.GetIsTouchingWall()) {
            ChangeAnimationState(((string[])characterState[currentCharacter])[4]);
        }
        else if (playerMovement.GetIsDoubleJump()) {
            ChangeAnimationState(((string[])characterState[currentCharacter])[5]);
        }
        else if (rb.velocity.y > 0.01f) {
            ChangeAnimationState(((string[])characterState[currentCharacter])[2]);
        }
        else if (rb.velocity.y < -0.01f) {
            ChangeAnimationState(((string[])characterState[currentCharacter])[1]);
        }
        else if (Mathf.Abs(rb.velocity.x) > 0) {
            ChangeAnimationState(((string[])characterState[currentCharacter])[3]);
        }
        else {
            ChangeAnimationState(((string[])characterState[currentCharacter])[0]);
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
