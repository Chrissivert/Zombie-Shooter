using System;
using UnityEngine;
using UnityEngine.Serialization;

public class IncreaseFireRate : MonoBehaviour
{
    public float fireratePowerUpDuration = 20f;
    public bool fireratePowerUpActivated;



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            DoublePlayersFireRate(collision.gameObject);
        }
    }
    
    public void DoublePlayersFireRate(GameObject player)
    {
        WeaponAttributes weaponAttributes = player.GetComponent<WeaponAttributes>();
        weaponAttributes.UpdateShootDelay(fireratePowerUpDuration);
    }
}
