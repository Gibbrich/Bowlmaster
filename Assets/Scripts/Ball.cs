using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public bool isInPlay = false;

    private Vector3 initialPosition;
    private new Rigidbody rigidbody;
    
    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    public void Launch(Vector3 velocity)
    {
        isInPlay = true;
        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Reset()
    {
        isInPlay = false;
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
    }
}