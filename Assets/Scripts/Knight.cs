// Script reference from 
// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmos.html
// https://docs.unity3d.com/ScriptReference/RaycastHit2D.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Knight : MonoBehaviour
{
    [SerializeField] public float attackCooldown;
    [SerializeField] public float attackRange;
    [SerializeField] public float collideDistance; 
    [SerializeField] public int damage;
    [SerializeField] public BoxCollider2D collide; 
    [SerializeField] public LayerMask knight; 
    private float cooldownTimer = Mathf.Infinity;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (playerInsight()) {
            if (cooldownTimer >= attackCooldown) {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
            }
        }
    }

    bool playerInsight() {
        RaycastHit2D hit = Physics2D.BoxCast(collide.bounds.center + transform.right * attackRange * transform.localScale.x * collideDistance , 
        new Vector3(collide.bounds.size.x * attackRange, collide.bounds.size.y, collide.bounds.size.z), 0, Vector2.left, 0, knight);
        return hit.collider != null;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(collide.bounds.center + transform.right * attackRange * transform.localScale.x * collideDistance, new Vector3(collide.bounds.size.x * attackRange, collide.bounds.size.y, collide.bounds.size.z));
    }

    public void damagePlayer() {
        if (playerInsight()) {

        }
    }
}
