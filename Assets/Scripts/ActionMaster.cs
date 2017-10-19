using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    private int[] bowls = new int[21];
    private int bowl = 1;

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins number: must be in range [0; 10]");
        }
        
        switch (pins)
        {
            case 10:
                return Action.END_TURN;
            default:
                throw new UnityException("Not sure what action to return");
        }
    }
    
    public enum Action
    {
        TIDY,
        RESET,
        END_TURN,
        END_GAME
    }
}