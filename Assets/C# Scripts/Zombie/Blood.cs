using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Blood2;
    public Zombie zombie;

    public void InstantiateBlood()
    {
        GameObject bloodInstance = Instantiate(Blood2, transform.position, Quaternion.identity);
        Destroy(bloodInstance, 0.1f);
    }

    public void DestroyBlood()
    {
        Destroy(Blood2);
    }
}
