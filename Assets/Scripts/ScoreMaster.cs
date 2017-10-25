using System.Collections.Generic;

public static class ScoreMaster
{
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        for (int i = 0; i < rolls.Count; i++)
        {
            // if frames in list = 10, stop counting other rolls (avoid case, when 1st bowl on 10 frame is strike)
            if (frameList.Count == 10)
            {
                break;
            }
            
            // handle strike
            int firstBowl = rolls[i];
            if (firstBowl == 10)
            {
                if (i + 1 < rolls.Count && i + 2 < rolls.Count)
                {
                    int secondBowl = rolls[i + 1];
                    int thirdBowl = rolls[i + 2];
                    
                    frameList.Add(firstBowl + secondBowl + thirdBowl);
                }
            }
            else
            {
                // handle non-strike
                if (i + 1 < rolls.Count)
                {
                    i++;
                    int secondBowl = rolls[i];

                    // handle spare
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
                        // handle common bowl
                        frameList.Add(firstBowl + secondBowl);
                    }
                }
            }
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