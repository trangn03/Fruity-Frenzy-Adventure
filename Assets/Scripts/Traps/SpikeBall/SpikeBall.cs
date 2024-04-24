using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpikeBall : MonoBehaviour
{
    [SerializeField] public float speed; // Speed of the spikeball
    [SerializeField] public float angle = 45.0f; // Initial angle of the spikeball
    [SerializeField] public float length = 3.0f; // Length of the chain
    [SerializeField] private float direct = 1.0f; // Initial direction
    public GameObject weight; // Weight of the spikeball
    public GameObject mount; // Mount of the spikeball
    private Vector3 pivot; // Pivot position
    private Vector3 bob; // Position of the weight

    public float GetAngle()
    {
        return this.angle;
    }

    void Start()
    {
        pivot = mount.transform.position; // Save the pivot position
        bob = weight.transform.position; // Save the position of the weight
    }

    void Update()
    {
        angle = direct*Mathf.Sin(Time.time * speed) * 45.0f; // Calculate the new angle of the spikeball
        // Calculate new position of the weight
        float x = Mathf.Sin(angle * Mathf.Deg2Rad) * length;
        float y = Mathf.Cos(angle * Mathf.Deg2Rad) * length;
        bob = pivot + new Vector3(x, -y, 0);

        weight.transform.position = bob; // Set the new position of the weight
    }

}
