using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Grenade : MonoBehaviour
{

    private Vector3 targetPos;
    public float greneadeSpeed;
    public GameObject explosionPrefab;
    public float radius = 5;
    public int explosionDamageToZombie = 1;
    public DamageText damageText;
    private HashSet<Zombie> damagedZombies;

    void Start()
    {
        targetPos = GameObject.Find("crosshair").transform.position;
        damagedZombies = new HashSet<Zombie>();
    }
    
    void Update()
    {
        if (greneadeSpeed > 0)
        {
            greneadeSpeed -= Random.Range(.1f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, greneadeSpeed * Time.deltaTime);
        }
        else if (greneadeSpeed <= 0)
        {
            greneadeSpeed = 0;
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        DamageListofZombies();
    }

    public void DamageListofZombies()
    {
        Collider2D[] enemyHitExplosion = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in enemyHitExplosion)
        {
            Zombie zombie = col.GetComponent<Zombie>();
            if (zombie != null && !damagedZombies.Contains(zombie))
            {
                zombie.RemoveHealth(explosionDamageToZombie);
                damageText.InstantiateDamageText(explosionDamageToZombie, zombie.transform.position, false);
                damagedZombies.Add(zombie);
            }
        }
    }
}
