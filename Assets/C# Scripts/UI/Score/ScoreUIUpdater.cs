using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI mainScoreText;
    public ScoreManager scoreManager;
    public GameObject changeScorePrefab;
    private float fadeTimer;
    public float fadeDuration = 2f;
    private TextMeshProUGUI GUIChangeScore;

    void Start()
    {
        UpdateMainScoreText();
        fadeTimer = fadeDuration;
        GUIChangeScore = changeScorePrefab.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        fadeTimer -= Time.deltaTime;

        if (fadeTimer <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            float alpha = fadeTimer / fadeDuration;
            GUIChangeScore.color = new Color(GUIChangeScore.color.r, GUIChangeScore.color.g, GUIChangeScore.color.b, alpha);
        }
    }

    public void UpdateMainScoreText()
    {
        mainScoreText.text = "" + scoreManager.score;
    }
    
    public void InstantiateChangeScoreText(int i)
    {
        fadeTimer = fadeDuration;
        GameObject damageInstance = Instantiate(changeScorePrefab, mainScoreText.transform.position, Quaternion.identity);
        GUIChangeScore = damageInstance.GetComponent<TextMeshProUGUI>();
        GUIChangeScore.text = i.ToString();
    }
}
