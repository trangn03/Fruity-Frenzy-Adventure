using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    [SerializeField] private float timeLife;
    private void Start()
    {
        Destroy(this.gameObject, timeLife);
    }
}