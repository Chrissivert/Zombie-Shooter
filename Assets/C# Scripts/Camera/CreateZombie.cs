using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZombie : MonoBehaviour
{

    public Zombie zombie;
    public GameObject zombiePrefab;
    public Transform playerPosition;
    public int amountOfZombiesToSpawn;
    public int amountOfWaves;
    public int timeBetweenWaves;
    void Start()
    {
        StartCoroutine(ZombiesToSpawnEachWaveAndForHowLong(amountOfZombiesToSpawn, amountOfWaves, timeBetweenWaves));
    }

    public void SpawnAmountOfZombies(int AmountOfZombies)
    {
        for (int i = 0; AmountOfZombies > i; i++)
        {
            Vector3 randomPosition = Random.insideUnitCircle.normalized * 10f;
            Vector3 playerPos = GameObject.Find("Player").transform.position;
            Vector3 spawnPosition = playerPos + randomPosition;

            GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            zombie.AddZombie(newZombie);
        }
    }

    public IEnumerator ZombiesToSpawnEachWaveAndForHowLong(int amountOfZombies, int waves, int interval)
    {
        for (int i = 0; waves > i; i++)
        {
            SpawnAmountOfZombies(amountOfZombies);
            yield return new WaitForSeconds(interval);
        }
    }
}


