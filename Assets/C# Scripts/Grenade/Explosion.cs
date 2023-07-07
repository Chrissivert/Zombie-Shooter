using UnityEngine;

public class MyScript : MonoBehaviour
{
    public float radius = 5;

    private void Update()
    {
        Collider2D[] enemyHitExplosion = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D col in enemyHitExplosion)
        {
            Zombie zombie = col.GetComponent<Zombie>();
            zombie.RemoveHealth(9999);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
