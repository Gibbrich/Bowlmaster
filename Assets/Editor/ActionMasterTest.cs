using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionMasterTest
{
    ActionMaster actionMaster = new ActionMaster();
    
    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        Assert.AreEqual(ActionMaster.Action.END_TURN, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        Assert.AreEqual(ActionMaster.Action.TIDY, actionMaster.Bowl(8));
    }
}