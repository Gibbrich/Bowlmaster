using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public int lastStandingCount = -1;
    public float DistanceToRaise = 50f;
    public Text PinsCounter;
    public GameObject PinSet;

    private Ball ball;
    private bool ballEnteredBox = false;
    private float lastChangeTime;

    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        PinsCounter.text = CountStanding().ToString();

        if (ballEnteredBox)
        {
            UpdateStandingCount();
        }
    }

    private void UpdateStandingCount()
    {
        // update the lastStandingCount
        int cirrentStanding = CountStanding();
        if (cirrentStanding != lastStandingCount)
        {
            lastStandingCount = cirrentStanding;
            lastChangeTime = Time.time;
            return;
        }

        float settleTime = 3f; // how long to wait to consider pins settled
        // call PinsHaveSettled() when they have
        if (Time.time - lastChangeTime >= settleTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1; // indicates pins have settled and ball not back in box
        ballEnteredBox = false;
        PinsCounter.color = Color.green;
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

    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Raise(DistanceToRaise);
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Lower(DistanceToRaise);
        }
    }

    public void RenewPins()
    {
        print("Renewing pins");
        Instantiate(PinSet, new Vector3(0, DistanceToRaise, 1829), Quaternion.identity);
    }
}