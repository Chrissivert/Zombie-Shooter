using UnityEngine;

public class PistolAttributes : MonoBehaviour, IWeaponAttributes
    {
        public float bulletSpeed = 10;
        public float shootDelay = 0.2f;

        public float getShootDelay()
        {
            return shootDelay;
        }

        public float getBulletSpeed()
        {
            return bulletSpeed;
        }
    }