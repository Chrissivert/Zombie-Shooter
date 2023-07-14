using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageText : MonoBehaviour
{
    public GameObject damagePrefab;
    // Start is called before the first frame update

    public void InstantiateDamageText(int damage)
    {
        GameObject damageInstance = Instantiate(damagePrefab, transform.position, Quaternion.identity);
        damageInstance.GetComponent<TextMesh>().text = damage.ToString();

        Destroy(damageInstance, 0.5f);
    }
}
