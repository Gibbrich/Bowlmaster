using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class ActionMasterTest
{
    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        Assert.AreEqual(ActionMaster.Action.END_TURN, ActionMaster.NextAction(new List<int>{10}));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        Assert.AreEqual(ActionMaster.Action.TIDY, ActionMaster.NextAction(new List<int>{8}));
    }

    [Test]
    public void T04Bowl28SpareReturnsEndTurn()
    {
        List<int> pinFalls = new List<int> {8,2};
        Assert.AreEqual(ActionMaster.Action.END_TURN, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {
        List<int> pinFalls = new List<int> {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
        Assert.AreEqual(ActionMaster.Action.RESET, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T06CheckResetAtSpareInLastFrame()
    {
        List<int> pinFalls = new List<int> {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
        Assert.AreEqual(ActionMaster.Action.RESET, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T07YouTubeRollsEndInEndGame()
    {
        List<int> pinFalls = new List<int> {8,2, 7,3, 3,4, 10,0, 2,8, 10,0, 10,0, 8,0, 10,0, 8,2,9};
        Assert.AreEqual(ActionMaster.Action.END_GAME, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T08GameEndsAtBowl20()
    {
        List<int> pinFalls = new List<int> {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
        Assert.AreEqual(ActionMaster.Action.END_GAME, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T09Bowl20AfterStrikeReturnsTidy()
    {
        List<int> pinFalls = new List<int> {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5};
        Assert.AreEqual(ActionMaster.Action.TIDY, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T10BensBowl20Test()
    {        
        List<int> pinFalls = new List<int> {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};
        Assert.AreEqual(ActionMaster.Action.TIDY, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T11NathanBowlIndexTest()
    {
        List<int> pinFalls = new List<int> {0,10, 5};
        Assert.AreEqual(ActionMaster.Action.TIDY, ActionMaster.NextAction(pinFalls));
        
        pinFalls.Add(1);
        Assert.AreEqual(ActionMaster.Action.END_TURN, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T12Dondi10thFrameTurkey()
    {        
        List<int> pinFalls = new List<int> {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
        Assert.AreEqual(ActionMaster.Action.RESET, ActionMaster.NextAction(pinFalls));
        
        pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.RESET, ActionMaster.NextAction(pinFalls));
        
        pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.END_GAME, ActionMaster.NextAction(pinFalls));
    }
}