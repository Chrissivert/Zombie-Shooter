using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject Blood2;

    public void InstantiateBlood(Vector3 zombiePosition)
    {
        GameObject bloodInstance = Instantiate(Blood2, zombiePosition, Quaternion.identity);
        Destroy(bloodInstance, 0.1f);
    }


}
