using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float zombiehealth;
    public List<GameObject> zombies;
    private bool explosion;

    void Update()
    {
        if (zombiehealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveHealth(float damage)
    {
        zombiehealth -= damage;
    }

    public void AddHealth(float healingAmount)
    {
        zombiehealth += healingAmount;
        zombiehealth = Mathf.Clamp(zombiehealth, 0, 100);

    }

    public void RemoveZombie(GameObject zombie)
    {
        zombies.Remove(zombie);

    }

    public void AddZombie(GameObject zombie)
    {
        zombies.Add(zombie);
    }

    public void ExplosionDamage(int amount)
    {
        if (!explosion)
        {
            explosion = true;
            zombiehealth -= amount;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(5f);
        explosion = false;
    }

}