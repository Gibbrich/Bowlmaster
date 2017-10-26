using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private List<int> rolls;
    private PinSetter pinSetter;
    public ScoreDisplay ScoreDisplay { get; private set; }
    public PinCounter PinCounter { get; private set; }
    public Ball Ball { get; private set; }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        
        rolls = new List<int>();
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
        rolls.Add(pinFall);      

        ScoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        ScoreDisplay.FillRolls(rolls);

        pinSetter.PerformAction(ActionMaster.NextAction(rolls));
        
        Ball.Reset();
    }
}