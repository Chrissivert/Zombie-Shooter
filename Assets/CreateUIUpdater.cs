using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateUIUpdater : MonoBehaviour
{
    public GameObject UIUpdaterInstance;
    void Update()
    {
        Instantiate(UIUpdaterInstance, transform.position, Quaternion.identity);
    }
}
