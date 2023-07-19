using System;
using UnityEngine;

public class IncreaseFireRate : MonoBehaviour
{
    public float doublefirerateduration = 20f;
    public bool fireratePowerUpActivated = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fireratePowerUpActivated = true;
            Destroy(gameObject);
            DoublePlayersFireRate(collision.gameObject);
        }
        Debug.Log(fireratePowerUpActivated);
    }

    public void DoublePlayersFireRate(GameObject player)
    {
        UpdateWeaponAttributes updateWeaponAttributes = player.GetComponent<UpdateWeaponAttributes>();
        updateWeaponAttributes.UpdateShootDelay(doublefirerateduration);
    }
}
