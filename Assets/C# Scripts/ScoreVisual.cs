using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{

    public ScoreManager dataScore;
    public GameObject scoreTextPrefab;
    Vector3 mainScoreXYZ = new Vector3(1f, 2f, 3f);

    public Color criticalColor = Color.red;

    public string CreateScoreText()
    {
        GameObject damageInstance = Instantiate(scoreTextPrefab, mainScoreXYZ, Quaternion.identity);
        TextMesh textMesh = damageInstance.GetComponent<TextMesh>();
        textMesh.text = dataScore.GetScore().ToString();
        return textMesh.text;
    }
}
