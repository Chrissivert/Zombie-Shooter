using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Animation explosionAnimation; // Reference to the Animation component

    public void StartExplosionAnimation()
    {
        explosionAnimation["Explosion"].speed = 1.0f;
        explosionAnimation.Play("Explosion");
    }
}
