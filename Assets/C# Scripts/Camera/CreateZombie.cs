using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZombie : MonoBehaviour
{

    public Zombie zombie;
    public GameObject zombiePrefab;
    public Transform playerPosition;
    public float initialSpawnInterval = 1f;
    public float spawnIntervalDecrease = 0.1f;
    public float minimumSpawnInterval = 0.5f;
    private float timer;
    public int amountOfZombiesToSpawn;
    public int amountOfWaves;
    public int timeBetweenWaves;

    private float currentSpawnInterval;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombiesToSpawnEachWaveAndForHowLong(amountOfZombiesToSpawn, amountOfWaves, timeBetweenWaves));
        ZombiesToSpawnEachWaveAndForHowLong(amountOfZombiesToSpawn, amountOfWaves, timeBetweenWaves);
    }

    private void Update()
    {
        timer = Time.deltaTime;
    }

    public void SpawnAmountOfZombies(int AmountOfZombies)
    {
        for (int i = 0; AmountOfZombies > i; i++)
        {
            Vector3 randomPosition = Random.insideUnitCircle.normalized * 10f;
            Vector3 spawnPosition = playerPosition.position + randomPosition;

            GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            zombie.AddZombie(newZombie);
        }
    }

    public IEnumerator ZombiesToSpawnEachWaveAndForHowLong(int amountOfZombies, int waves, int interval)
    {
        Debug.Log("Before loop");
        for (int i = 0; waves > i; i++)
        {
            Debug.Log("Start loop");
            SpawnAmountOfZombies(amountOfZombies);
            yield return new WaitForSeconds(interval);
        }
        Debug.Log("Outside loop");
    }
}


