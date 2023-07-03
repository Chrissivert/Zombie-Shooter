using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 100f;
    public GameObject zombiePrefab;

    [SerializeField] private AudioSource takeDamage;


    private void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        UpdateHealthBar();
        takeDamage.Play();
        Destroy(gameObject);
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = healthAmount / 100f;
    }
}
