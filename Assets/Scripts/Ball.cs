using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public float velocityForce = 200;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * velocityForce;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}