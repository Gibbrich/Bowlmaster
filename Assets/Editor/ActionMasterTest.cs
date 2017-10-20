using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster actionMaster;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }
    
    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        Assert.AreEqual(ActionMaster.Action.END_TURN, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl0To9ReturnsTidy()
    {
        actionMaster = new ActionMaster();
        Assert.AreEqual(ActionMaster.Action.TIDY, actionMaster.Bowl(0));
        
        actionMaster = new ActionMaster();
        Assert.AreEqual(ActionMaster.Action.TIDY, actionMaster.Bowl(5));
        
        actionMaster = new ActionMaster();
        Assert.AreEqual(ActionMaster.Action.TIDY, actionMaster.Bowl(9));
    }
    
    [Test]
    public void T03BowlsSpareReturnsEndTurn()
    {
        actionMaster.Bowl(1);
        Assert.AreEqual(ActionMaster.Action.END_TURN, actionMaster.Bowl(9));

        // if player bowls first for 0 and second for 10 - it is also spare
        actionMaster = new ActionMaster();
        actionMaster.Bowl(0);
        Assert.AreEqual(ActionMaster.Action.END_TURN, actionMaster.Bowl(10));
    }

    [Test]
    public void T04Bowls29ThrowsArgumentException()
    {
        // in case if 2nd call actionMaster.Bowl() with number of pins > remained on field
        actionMaster.Bowl(2);
        Assert.Throws<ArgumentException>(() => actionMaster.Bowl(9));
    }

    [Test]
    public void T05BowlLess0OrMore10ThrowsArgumentException()
    {
        actionMaster = new ActionMaster();
        Assert.Throws<ArgumentException>(() => actionMaster.Bowl(11));
        
        actionMaster = new ActionMaster();
        Assert.Throws<ArgumentException>(() => actionMaster.Bowl(-1));
    }

    [Test]
    public void T06BowlsTwiceReturnEndTurn()
    {
        actionMaster.Bowl(3);
        Assert.AreEqual(ActionMaster.Action.END_TURN, actionMaster.Bowl(5));
    }

    [Test]
    public void T07BowlSpare10FrameReturnReset()
    {
        for (int i = 0; i < 9; i++)
        {
            actionMaster.Bowl(3);
            actionMaster.Bowl(3);
        }

        actionMaster.Bowl(3);
        Assert.AreEqual(ActionMaster.Action.RESET, actionMaster.Bowl(7));
    }

    [Test]
    public void T08Strike10FrameReturnReset()
    {
        for (int i = 0; i < 9; i++)
        {
            actionMaster.Bowl(3);
            actionMaster.Bowl(3);
        }
        
        Assert.AreEqual(ActionMaster.Action.RESET, actionMaster.Bowl(10));
    }

    [Test]
    public void T09BonusBowlReturnEndGame()
    {
        // case bonus bowls strikes 0 pins
        for (int i = 0; i < 10; i++)
        {
            actionMaster.Bowl(5);
            actionMaster.Bowl(5);
        }
        
        Assert.AreEqual(ActionMaster.Action.END_GAME, actionMaster.Bowl(0));

        // case bonus bowl strikes 10 pins
        actionMaster = new ActionMaster();
        for (int i = 0; i < 10; i++)
        {
            actionMaster.Bowl(5);
            actionMaster.Bowl(5);
        }
        
        Assert.AreEqual(ActionMaster.Action.END_GAME, actionMaster.Bowl(10));
    }
}