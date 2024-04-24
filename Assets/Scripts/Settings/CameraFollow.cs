// Script referenced from Unity Example 1 in class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float offsetY = 0;

    void Start()
    {
        if (!target)
        {
            enabled = false;
            Debug.Log("No target");
        }
    }

    void Update()
    {
        if (target)
        {
            Vector3 targetPosition = target.position;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);
            targetPosition.y += offsetY; // Apply the offset
            targetPosition.z = transform.position.z; // Maintain the camera's z level
            transform.position = targetPosition;
        }
    }
}
