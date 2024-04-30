using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    [SerializeField] private GameObject weight; 
    [SerializeField] private GameObject mount; 
    [SerializeField] private GameObject chains;
    private Transform transformChains;
    private SpikeBall spikeBall;

    // Start is called before the first frame update
    void Start()
    {
        chains.transform.position = (weight.transform.position + mount.transform.position) / 2f;
        transformChains = chains.transform;
        GameObject spikedBall = transform.parent.Find("Spiked Ball").gameObject;
        spikeBall = spikedBall.GetComponent<SpikeBall>();
    }

    // Update is called once per frame
    void Update()
    {
        transformChains.position = (weight.transform.position + mount.transform.position) / 2f;
        transformChains.rotation = Quaternion.Euler(transformChains.rotation.eulerAngles.x, transformChains.rotation.eulerAngles.y, spikeBall.GetAngle());
    }
}
