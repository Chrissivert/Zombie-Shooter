using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject Blood2;

    public void InstantiateBlood()
    {
        GameObject bloodInstance = Instantiate(Blood2, transform.position, Quaternion.identity);
        Destroy(bloodInstance, 0.1f);
    }


}
