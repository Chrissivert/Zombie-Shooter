using UnityEngine;

public class CurrentWeaponAttributes: MonoBehaviour
    {
        private float bulletSpeed = 20;
        private float shootDelay = 500f;
        private float shotgunSpreadAngle = 30;

        public float getBulletSpeed()
        {
            return bulletSpeed;
        }
        
        public float getShootDelay()
        {
            return shootDelay;
        }
        
        public float getShotgunSpreadAngle()
        {
            return shotgunSpreadAngle;
        }

        public void setBulletSpeed(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }
    
    public void setShootDelay(float shootDelay)
    {
        this.shootDelay = shootDelay;
    }
    
    public void setShotgunSpreadAngle(float shotgunSpreadAngle)
    {
        this.shotgunSpreadAngle = shotgunSpreadAngle;
    }
}