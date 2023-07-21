using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI changeScoreText;
    int score;
    private float fadeTimer;
    public float fadeDuration = 2f;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        fadeTimer -= Time.deltaTime;

            if (fadeTimer <= 0f)
            {
                //
            }
            else
            {
                float alpha = fadeTimer / fadeDuration;
                changeScoreText.color = new Color(changeScoreText.color.r, changeScoreText.color.g, changeScoreText.color.b, alpha);
            }
    }

    public int AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
        return score;
    }

    public void RemoveScore(int scoreToRemove)
    {
        score -= scoreToRemove;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateScoreText()
    {
        scoreText.text = ""+ score;
        changeScoreText.text = "10";
    }
}
