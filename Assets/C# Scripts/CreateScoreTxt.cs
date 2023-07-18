using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateScoreTxt : MonoBehaviour
{

    public ScoreManager scoreManager;
    public GameObject scoreTextPrefab;
    Vector3 mainScoreXYZ = new Vector3(1f, 2f, 3f);

    private int previousScore;

    public Color criticalColor = Color.red;


    void Start()
    {
       CreateScoreText();
       previousScore = scoreManager.GetScore();
    }

    private void Update()
    {
        if (scoreManager.GetScore() != previousScore)
        {
            CreateScoreText();
            previousScore = scoreManager.GetScore();
        }
    }

    public string CreateScoreText()
    {
        GameObject damageInstance = Instantiate(scoreTextPrefab, mainScoreXYZ, Quaternion.identity);
        TextMesh textMesh = damageInstance.GetComponent<TextMesh>();
        textMesh.text = scoreManager.GetScore().ToString();
        return textMesh.text;
    }
}
