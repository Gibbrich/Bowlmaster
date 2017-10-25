using System.Collections.Generic;

public static class ScoreMaster
{
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int frame = 1;
        for (int i = 0; i < rolls.Count; i++)
        {
            int firstBowl = rolls[i];
            if (firstBowl == 10)
            {
                if (i + 1 < rolls.Count && i + 2 < rolls.Count)
                {
                    int secondBowl = rolls[i + 1];
                    int thirdBowl = rolls[i + 2];
                    
                    frameList.Add(firstBowl + secondBowl + thirdBowl);
                }
                
                //when strike at first bowl on 10 frame - just return
                if (frame == 10)
                {
                    return frameList;
                }
            }
            else
            {
                if (i + 1 < rolls.Count)
                {
                    i++;
                    int secondBowl = rolls[i];

                    if (firstBowl + secondBowl == 10)
                    {
                        if (i + 1 < rolls.Count)
                        {
                            int thirdBowl = rolls[i + 1];
                            
                            frameList.Add(firstBowl + secondBowl + thirdBowl);
                        }
                    }
                    else
                    {
                        frameList.Add(firstBowl + secondBowl);
                    }
                }
            }
            
            frame++;
        }
        return frameList;
    }

    public static List<int> ScoreCumulative(List<int> rolls)
    {
        int runningTotal = 0;
        List<int> cumulativeScores = new List<int>();
        foreach (int scoreFrame in ScoreFrames(rolls))
        {
            runningTotal += scoreFrame;
            cumulativeScores.Add(runningTotal);
        }
        return cumulativeScores;
    }
}