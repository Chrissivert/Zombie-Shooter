using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NukePowerUp : MonoBehaviour
{

    public string zombieTag = "Zombie";
    public ScreenFlash screenFlash;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ExplodeNuke();
            Destroy(gameObject);
        }
    }

    public void ExplodeNuke()
    {
        // Find all game objects with the specified name
        GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag(zombieTag);
        screenFlash.ScreenFlash2();

        // Iterate over the found objects and destroy them++
        foreach (GameObject obj in objectsToRemove)
        {
            Destroy(obj);
        }
    }
}

