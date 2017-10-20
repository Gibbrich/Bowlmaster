using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    private int[] bowls = new int[21];
    private int bowl = 1;
    private int lastBowlPinsCount = 0;

    // todo refactor
    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new ArgumentException("Invalid pins number. For first bowl must be in range [0; 10]");
        }

        int pinsInGame = 10 - lastBowlPinsCount;

        if (lastBowlPinsCount != 0 && pinsInGame - pins < 0)
        {
            throw new ArgumentException(string.Format("Invalid pins number. For second bowl must be in range [0; {0}]", 10 - lastBowlPinsCount));
        }

        // other behaviour here, e.g. last frame

        if (pins == 10)
        {
            Action action;
            
            if (bowl == 19)
            {
                action = Action.RESET;
            }
            else if (bowl == 21)
            {
                action = Action.END_GAME;
            }
            else
            {
                action = Action.END_TURN;
            }
            
            bowl += 2;
            return action;
        }

        // if at the mid frame (or last frame)
        if (bowl % 2 != 0)
        {
            Action action;
            if (bowl == 21)
            {
                action = Action.END_GAME;
            }
            else
            {
                action = Action.TIDY;
            }
            
            bowl++;
            lastBowlPinsCount = pins;
            return action;
        }
        else
        {
            Action action;
            
            if (bowl == 20 && pinsInGame - pins == 0)
            {
                action = Action.RESET;
            }
            else
            {
                action = Action.END_TURN;
            }
            
            bowl++;
            lastBowlPinsCount = 0;
            return action;
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