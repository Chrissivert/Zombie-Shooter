using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public int damage;
    public float damageInterval = 0.5f; // Time interval between each damage
    private float timer; // Timer to keep track of time passed
    public PlayerHealth playerHealth;

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if enough time has passed since the last damage
        if (timer >= damageInterval && collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            timer = 0f; // Reset the timer
        }
    }
}