using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public Text PinsCounter;

    private bool ballEnteredBox = false;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PinsCounter.text = CountStanding().ToString();
    }

    private int CountStanding()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            PinsCounter.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Pin>())
        {
            Destroy(other.gameObject);
        }
    }
}