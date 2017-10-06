using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public Vector3 launchVelocity = new Vector3(0, 0, 200);

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = launchVelocity;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}