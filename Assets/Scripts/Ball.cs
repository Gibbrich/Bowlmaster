using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public bool IsInPlay { get; private set; }
    public bool IsEnteredPinSetter { get; set; }
    public bool IsBallOutOfLane { get; set; }

    private Vector3 initialPosition;
    private new Rigidbody rigidbody;

    public Ball()
    {
        IsInPlay = false;
        IsEnteredPinSetter = false;
        IsBallOutOfLane = false;
    }

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    public void Launch(Vector3 velocity)
    {
        IsInPlay = true;
        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;
        GetComponent<AudioSource>().Play();
    }

    public void Reset()
    {
        IsInPlay = false;
        IsEnteredPinSetter = false;
        IsBallOutOfLane = false;
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PinSetter>())
        {
            IsEnteredPinSetter = true;
        }
    }
}