using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    float z = -5; // Used to maintain the camera's z level, sometimes important for rendering

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
            z = transform.position.z;
            Vector3 targetPosition = target.position;
            targetPosition.z = z;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);
            transform.position = targetPosition;
        }
    }
}
