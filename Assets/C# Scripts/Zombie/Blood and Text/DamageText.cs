using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageText : MonoBehaviour
{
    public GameObject damagePrefab;
    public float fadeDuration = 2f;
    private TextMesh textMesh;
    private float fadeTimer;
    public Transform zombiePosition;

    public Color normalColor = Color.white;
    public Color criticalColor = Color.red;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        fadeTimer = fadeDuration;
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
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
        }
    }

    public void InstantiateDamageText(int damage, Vector3 zombiePosition, bool isCriticalHit)
    {
        GameObject damageInstance = Instantiate(damagePrefab, zombiePosition, Quaternion.identity);
        textMesh = damageInstance.GetComponent<TextMesh>();

        if (isCriticalHit)
        {
            textMesh.color = criticalColor;
        }
        else
        {
            textMesh.color = normalColor;
        }

        textMesh.text = damage.ToString();
    }

}
