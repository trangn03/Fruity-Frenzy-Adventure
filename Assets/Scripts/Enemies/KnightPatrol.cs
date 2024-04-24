using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnightPatrol : MonoBehaviour
{   
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    public Vector3 initScale;
    bool moveLeft;
    [SerializeField] public float idleState; 
    public float idleTimer;

    [SerializeField] public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft) {
            if (enemy.position.x >= left.position.x) {
                moveinDirection(-1);
            }
            else {
                directionChange();
            }
        }
        else {
            if (enemy.position.x <= right.position.x) {
                moveinDirection(1);
            }
            else {
                directionChange();
            }
        }
    }

    public void directionChange() {
        animator.SetBool("Moving", false);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleState) {
            moveLeft = !moveLeft;
        }
    }
    void Awake() {
        initScale = enemy.localScale;
    }

    public void moveinDirection(int direction) {
        idleTimer = 0;
        animator.SetBool("Moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        enemy.position =new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }
    public void OnDisable() {
        animator.SetBool("Moving", false);
    }
}
