﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float StandingThreshold = 10;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsStanding()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        float tiltX = Mathf.Abs(270 - Mathf.Abs(rotation.x));
        float tiltZ = Mathf.Abs(rotation.z);

        return tiltX < StandingThreshold && tiltZ < StandingThreshold;
    }
}