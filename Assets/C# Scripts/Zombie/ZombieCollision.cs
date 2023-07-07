using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    public int zombiedamage;
    public int bulletdamage;
    public float damageInterval = 0.5f;
    private float timer;
    public Zombie zombie;
    public Blood blood;
    PlayerHealth playerHealth;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if enough time has passed since the last damage
        if (timer >= damageInterval && collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(zombiedamage);
            timer = 0f; // Reset the timer
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            zombie.RemoveHealth(bulletdamage);
            blood.InstantiateBlood();
        }
    }
}