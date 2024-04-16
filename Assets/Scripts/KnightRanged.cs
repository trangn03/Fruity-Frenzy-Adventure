using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRanged : MonoBehaviour
{
    [SerializeField] public float attackCooldown;
    [SerializeField] public float attackRange;
    [SerializeField] public float collideDistance; 
    [SerializeField] public int damage;
    [SerializeField] public BoxCollider2D collide;
    [SerializeField] public LayerMask knight; 
    private float cooldownTimer = Mathf.Infinity;
    public Animator animator;
    public KnightPatrol knightPatrol;
    [SerializeField] public Transform firepoint; 
    [SerializeField] public GameObject[] fireballs; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        knightPatrol = GetComponentInParent<KnightPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (playerInsight()) {
            if (cooldownTimer >= attackCooldown) {
                cooldownTimer = 0;
                animator.SetTrigger("RangeAttack");
            }
        }
        if (knightPatrol != null) {
            knightPatrol.enabled = !playerInsight();
        }
    }

    public void RangeAttack() {
        cooldownTimer = 0;
        // Shoot projectile
        fireballs[findFireball()].transform.position = firepoint.position;
        // fireballs[findFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    public int findFireball() {
        for (int i = 0; i < fireballs.Length; i++) {
            if (!fireballs[i].activeInHierarchy) {
                return i;
            }
        }
        return 0;
    }

    public bool playerInsight() {
        RaycastHit2D hit = Physics2D.BoxCast(collide.bounds.center + transform.right * attackRange * transform.localScale.x * collideDistance , 
        new Vector3(collide.bounds.size.x * attackRange, collide.bounds.size.y, collide.bounds.size.z), 0, Vector2.left, 0, knight);
        return hit.collider != null;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(collide.bounds.center + transform.right * attackRange * transform.localScale.x * collideDistance, new Vector3(collide.bounds.size.x * attackRange, collide.bounds.size.y, collide.bounds.size.z));
    }

}
