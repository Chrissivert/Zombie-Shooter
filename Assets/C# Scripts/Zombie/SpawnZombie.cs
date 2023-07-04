using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public Zombie zombie;
    public GameObject zombiePrefab;
    public Transform playerPosition;
    public float initialSpawnInterval = 1f;
    public float spawnIntervalDecrease = 0.1f;
    public float minimumSpawnInterval = 0.5f;
    private float timer;

    private float currentSpawnInterval;

    private void Start()
    {
        // currentSpawnInterval = initialSpawnInterval;
       // InvokeRepeating("SpawnNewZombie", currentSpawnInterval, currentSpawnInterval);
    }

    private void Update()
    {

    }
}
