using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public float moveSpeedMultiplier = 1.5f;
    public int durationForSpeedPowerUp = 20;

    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            DoubleMovementSpeed(collision.gameObject);
        }
    }
    public void DoubleMovementSpeed(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.UpdateMovementSpeed(moveSpeedMultiplier, durationForSpeedPowerUp);
    }
}
