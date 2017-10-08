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
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void Launch(Vector3 velocity)
    {
        GameManager.IsGameStarted = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = velocity;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}