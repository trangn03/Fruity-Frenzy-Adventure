using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, 360 * speed * Time.deltaTime);
    }
}
