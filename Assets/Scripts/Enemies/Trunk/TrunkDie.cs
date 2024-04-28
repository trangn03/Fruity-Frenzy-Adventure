using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkDie : MonoBehaviour
{
    private MovingWithWaitTime movingWithWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        movingWithWaitTime = this.transform.parent.GetComponent<MovingWithWaitTime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("PointKill")) {
            movingWithWaitTime.enabled = false;
        }
    }
}
