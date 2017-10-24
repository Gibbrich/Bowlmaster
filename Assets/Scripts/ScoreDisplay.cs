using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour
{
    private Text scoreText;

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
}