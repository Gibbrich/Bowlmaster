using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private List<int> pins;
    private PinSetter pinSetter;
    public ScoreDisplay ScoreDisplay { get; private set; }
    public PinCounter PinCounter { get; private set; }
    public Ball Ball { get; private set; }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        
        pins = new List<int>();
        pinSetter = FindObjectOfType<PinSetter>();
        ScoreDisplay = FindObjectOfType<ScoreDisplay>();
        Ball = FindObjectOfType<Ball>();
        PinCounter = FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateScore(int pinFall)
    {
        pins.Add(pinFall);
        if (pinFall == 10 && pins.Count % 2 != 0)
        {
            // if strike was on 1st bowl, add 0 to the pins, as if 2nd bowl was 0
            pins.Add(0);
        }        

        List<int> scoreFrames = ScoreMaster.ScoreFrames(pins);
        ScoreDisplay.UpdateScore(scoreFrames);
        
        ActionMaster.Action action = ActionMaster.NextAction(pins);
        pinSetter.PerformAction(action);
        
        Ball.Reset();
    }
}