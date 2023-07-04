using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public float Force;
    public Rigidbody2D rb;

    public GameObject Blood2;

    private void Update()
    {
        rb.AddForce(transform.up * Force * Time.fixedDeltaTime, ForceMode2D.Impulse);
        //Destroy(gameObject, 3f);
    }

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
