using UnityEngine;

public class ShotgunAttributes : MonoBehaviour, IWeaponAttributes
    {
        public float bulletSpeed = 5;
        public float shootDelay = 0.4f;
        public float shotgunSpreadAngle;

        public float getShootDelay()
        {
            return shootDelay;
        }

        public float getBulletSpeed()
        {
            return bulletSpeed;
        }

        public float getShotgunSpreadAngle()
        {
            return shotgunSpreadAngle;
        }
    }
