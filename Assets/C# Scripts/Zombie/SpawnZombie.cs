using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform player;
    public float initialSpawnInterval = 1f;
    public float spawnIntervalDecrease = 0.1f;
    public float minimumSpawnInterval = 0.5f;

    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating("SpawnNewZombie", currentSpawnInterval, currentSpawnInterval);
    }

    private void SpawnNewZombie()
    {
        // Calculate a random position around the player
        Vector3 randomPosition = Random.insideUnitCircle.normalized * 10f;
        Vector3 spawnPosition = player.position + randomPosition;

        // Instantiate a new zombie at the calculated position
        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

        // Optional: Set up any additional settings or behavior for the new zombie

        // Decrease the spawn interval by the specified amount
        currentSpawnInterval -= spawnIntervalDecrease;

        // Clamp the spawn interval to the minimum value
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minimumSpawnInterval);

        // Cancel the previous InvokeRepeating and start a new one with the updated spawn interval
        CancelInvoke("SpawnNewZombie");
        InvokeRepeating("SpawnNewZombie", currentSpawnInterval, currentSpawnInterval);
    }
}
