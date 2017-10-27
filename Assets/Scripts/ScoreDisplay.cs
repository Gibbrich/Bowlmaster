using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text scoreText;

    [SerializeField] 
    private Text[] scoreBoxes;
    [SerializeField] 
    private Text[] scoreFrames;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(List<int> scoreFrames)
    {
        SetScoreColor(Color.green);
        // todo implement
    }

    public void SetPinsCount(int pinStandingCount)
    {
        scoreText.text = pinStandingCount.ToString();
    }

    public void SetScoreColor(Color color)
    {
        scoreText.color = color;
    }

    public void FillRolls(List<int> rolls)
    {
        string formatRolls = FormatRolls(rolls);
        for (int i = 0; i < formatRolls.Length; i++)
        {
            scoreBoxes[i].text = formatRolls[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            scoreFrames[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1; // Score box 1 to 21 

            if (rolls[i] == 0)
            {
                // Always enter 0 as -
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10)
            {
                // SPARE
                output += "/";
            }
            else if (box >= 19 && rolls[i] == 10)
            {
                // STRIKE in frame 10
                output += "X";
            }
            else if (rolls[i] == 10)
            {
                // STRIKE in frame 1-9
                output += "X ";
            }
            else
            {
                output += rolls[i].ToString(); // Normal 1-9 bowl
            }
        }

        return output;
    }
}