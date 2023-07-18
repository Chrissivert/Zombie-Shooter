using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    public int zombiedamage;
    public int minBulletDamage = 20;
    public int maxBulletDamage = 30;
    public float damageInterval = 0.5f;
    public float criticalHitChance = 0.2f;
    private float timer;
    public Zombie zombie;
    public Blood blood;
    public DamageText damageText;
    PlayerHealth playerHealth;
    public bool zombieHitByBullet = false;

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
        if (timer >= damageInterval && collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(zombiedamage);
            timer = 0f; // Reset the timer
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Inside Enter");
            SetZombieHitByBullet(true);

            int randomDamage = CreateRandomDamage(minBulletDamage, maxBulletDamage);

            if (Random.value <= criticalHitChance)
            {
                randomDamage *= 2;
                zombie.RemoveHealth(randomDamage);
                blood.InstantiateBlood(transform.position);
                damageText.InstantiateDamageText(randomDamage, transform.position, true);
            }
            else
            {
                zombie.RemoveHealth(randomDamage);
                blood.InstantiateBlood(transform.position);
                damageText.InstantiateDamageText(randomDamage, transform.position, false);
            }
            Destroy(collision.gameObject);
        }
    }


    private int CreateRandomDamage(int minBulletDamage, int maxBulletDamage)
    {
        int randomDamage = Random.Range(minBulletDamage, maxBulletDamage + 1); // Generate random damage within the range
        return randomDamage;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Inside exit");
            SetZombieHitByBullet(false);
        }
    }

    public void SetZombieHitByBullet(bool value)
    {
        zombieHitByBullet = value;
    }

    public bool GetZombieHitByBullet()
    {
        return zombieHitByBullet;
    }
}
