using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
    {

         public float timeBetweenEachPowerUp = 3f;
         public GameObject[] powerUpPrefabs; // The prefab of the power-up
         public Vector3 minSpawnPosition = new Vector3(-9f, 0f, 0f); // The minimum position of the spawn area
         public Vector3 maxSpawnPosition = new Vector3(7f, 9f, 0f); // The maximum position of the spawn area

        private Coroutine spawnCoroutine; // Reference to the active spawn coroutine

        private void Start()
        {
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(SpawnPowerUpRoutine());
            }
        }

        private IEnumerator SpawnPowerUpRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeBetweenEachPowerUp);

                // Generate a random position within the spawn area
                Vector3 randomPosition = GetRandomPositionInArea();

            int randomIndex = Random.Range(0, powerUpPrefabs.Length);

            // Instantiate the power-up prefab at the random position
            Instantiate(powerUpPrefabs[randomIndex], randomPosition, Quaternion.identity);
            }
        }

        private Vector3 GetRandomPositionInArea()
        {
            // Calculate a random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
                Random.Range(minSpawnPosition.y, maxSpawnPosition.y),
                Random.Range(minSpawnPosition.z, maxSpawnPosition.z)
            );

            return randomPosition;
        }
    }

