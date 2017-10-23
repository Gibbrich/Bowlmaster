using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour
{
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private int pinsStandingCount = 10;

    public void ResetPinsStandingCount()
    {
        pinsStandingCount = 10;
    }

    private void Update()
    {
        if (GameManager.Instance.Ball.IsEnteredPinSetter)
        {
            UpdateStandingCount();
            GameManager.Instance.ScoreDisplay.SetScoreColor(Color.red);
        }
    }
    
    private void UpdateStandingCount()
    {
        // update the lastStandingCount
        int currentStanding = Pin.CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastStandingCount = currentStanding;
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
        int pinStandingCount = Pin.CountStanding();
        int pinFall = pinsStandingCount - pinStandingCount;
        pinsStandingCount = pinStandingCount;
        lastStandingCount = -1; // indicates pins have settled and ball not back in box
        
        GameManager.Instance.UpdateScore(pinFall);
    }

}