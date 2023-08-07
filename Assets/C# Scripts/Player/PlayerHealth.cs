using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    private float timer = 0f;

    [SerializeField] private AudioSource takeDamage;
    
    void Update()
    {
        timer += Time.deltaTime;

        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (healthAmount < 100 && timer >= 1 )
        {
            Heal(4);
            timer = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        UpdateHealthBar();
        takeDamage.Play();
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        UpdateHealthBar();

    }

    
    //Maybe put this method in UIScript
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = healthAmount / 100f;
    }
}
