using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMesh scoreText;
    public ZombieCollision zombieCollision;
    int score = 0;

    private void Start()
    {
        score = 5;
    }

    private void Update()
    {
        if(zombieCollision.GetZombieHitByBullet() == true)
        {
            AddScore(10);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
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
        scoreText.text = score.ToString();
    }
}
