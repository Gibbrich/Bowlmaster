using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float StandingThreshold = 10;

    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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

    public void Raise(float height)
    {
        if (IsStanding())
        {
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            transform.rotation = Quaternion.Euler(270, 0, 0);
            transform.position += new Vector3(0, height, 0);
        }
    }

    public void Lower(float height)
    {
        if (IsStanding())
        {
            transform.position -= new Vector3(0, height, 0);
            rigidbody.useGravity = true;
            rigidbody.isKinematic = false;
        }
    }
    
    public static int CountStanding()
    {
        int standingCount = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standingCount++;
            }
        }
        return standingCount;
    }
}