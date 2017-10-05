using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball Ball;

    private Vector3 offset;
    
    // Use this for initialization
    void Start()
    {
        offset = new Vector3(0, 54, -160);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.gameObject.transform.position.z <= 1800)
        {
            transform.position = Ball.gameObject.transform.position + offset;
        }
    }
}