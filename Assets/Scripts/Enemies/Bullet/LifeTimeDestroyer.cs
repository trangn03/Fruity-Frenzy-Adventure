using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    [SerializeField] private float timeLife;

    [Obsolete]
    private void Start()
    {
        DestroyObject(this.transform.gameObject, timeLife);
    }
}