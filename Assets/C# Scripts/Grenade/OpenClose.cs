using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Animation explosionAnimation; // Reference to the Animation component

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            explosionAnimation.Play();
        }
    }
}
