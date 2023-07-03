using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerZombie : MonoBehaviour
{
    public List<GameObject> zombies;

    public void RemoveZombie(GameObject zombie)
    {
        zombies.Remove(zombie);
        
    }

    public void AddZombie(GameObject zombie)
    {
        zombies.Add(zombie);
    }
}
