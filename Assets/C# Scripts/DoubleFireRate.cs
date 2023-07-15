using UnityEngine;

public class IncreaseFireRate : MonoBehaviour
{
    public int doublefirerateduration = 20;

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
        PointAndShoot pointAndShoot = player.GetComponent<PointAndShoot>();
        pointAndShoot.UpdateShootDelay(pointAndShoot.shootDelay, doublefirerateduration);
    }
}
