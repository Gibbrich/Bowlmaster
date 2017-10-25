using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinfFalls)
    {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach (int pinFall in pinfFalls)
        {
            currentAction = am.Bowl(pinFall);
        }

        return currentAction;
    }

    private Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid pins");
        }

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.END_GAME;
        }

        // Handle last-frame special cases
        if (bowl >= 19 && pins == 10)
        {
            bowl++;
            return Action.RESET;
        }
        else if (bowl == 20)
        {
            bowl++;
            if (bowls[19 - 1] == 10 && bowls[20 - 1] == 0)
            {
                return Action.TIDY;
            }
            else if (bowls[19 - 1] + bowls[20 - 1] == 10)
            {
                return Action.RESET;
            }
            else if (Bowl21Awarded())
            {
                return Action.TIDY;
            }
            else
            {
                return Action.END_GAME;
            }
        }

        if (bowl % 2 != 0)
        {
            // First bowl of frame
            if (pins == 10)
            {
                bowl += 2;
                return Action.END_TURN;
            }
            else
            {
                bowl += 1;
                return Action.TIDY;
            }
        }
        else if (bowl % 2 == 0)
        {
            // Second bowl of frame
            bowl += 1;
            return Action.END_TURN;
        }

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded()
    {
        // Remember that arrays start counting at 0
        return bowls[19 - 1] + bowls[20 - 1] >= 10;
    }
    
    public enum Action
    {
        TIDY,
        RESET,
        END_TURN,
        END_GAME
    }
}