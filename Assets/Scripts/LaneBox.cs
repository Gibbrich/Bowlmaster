using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            FindObjectOfType<PinSetter>().IsBallOutOfPlay = true;
        }
    }
}