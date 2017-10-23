using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour
{
    public bool IsBallOutOfLane { get; set; }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            // todo use this flag
            IsBallOutOfLane = true;
        }
    }
}