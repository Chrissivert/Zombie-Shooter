using System;
using UnityEngine;

public class IncreaseFireRate : MonoBehaviour
{
    public float doublefirerateduration = 20f;
    public bool fireratePowerUpActivated = false;

    private void Start()
    {
        fireratePowerUpActivated = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fireratePowerUpActivated = true;
            Destroy(gameObject);
            DoublePlayersFireRate(collision.gameObject);
        }
    }

    public void DoublePlayersFireRate(GameObject player)
    {
        WeaponAttributes weaponAttributes = player.GetComponent<WeaponAttributes>();
        weaponAttributes.UpdateShootDelay(doublefirerateduration);
    }
}
