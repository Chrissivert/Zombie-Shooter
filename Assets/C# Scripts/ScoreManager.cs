using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI changeScoreText;
    public int score;
    private float fadeTimer;
    public float fadeDuration = 2f;
    public ScoreUIUpdater scoreUIUpdater;

    public int AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreUIUpdater.UpdateMainScoreText();
        return score;
    }

    public int RemoveScore(int scoreToRemove)
    {
        score -= scoreToRemove;
        scoreUIUpdater.UpdateMainScoreText();
        return score;
    }

    public int GetScore()
    {
        return score;
    }
}
