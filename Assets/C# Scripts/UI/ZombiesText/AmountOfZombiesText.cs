using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfZombiesText : MonoBehaviour
{
    private TextMesh textMesh;
    public Zombie zombie;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public int AmountOfZombies(List<GameObject> zombies)
    {
        int amountOfZombiesOnStage = 0;
        foreach (GameObject zombie in zombies)
        {
            amountOfZombiesOnStage++;
        }

        return amountOfZombiesOnStage;
    }

}
