using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    
    public float bulletSpeed;
    public float shootDelay;
    public float shotgunSpreadAngle;
    public IncreaseFireRate increaseFireRate;
    public BulletSpeedPowerUp bulletSpeedPowerUp;

    private void Start()
    {
        increaseFireRate.fireratePowerUpActivated = false;
        bulletSpeedPowerUp.bulletSpeedPowerUpActivated = false;
    }

    public void PistolAttributes()
    {
        bulletSpeed = 15.0f;
        shootDelay = 0.25f;
        
        if(increaseFireRate.fireratePowerUpActivated)
        {
            shootDelay /= 2f;
        }
        
        if(bulletSpeedPowerUp.bulletSpeedPowerUpActivated)
        {
            bulletSpeed *= 2f;
        }
    }

    public void ShotgunAttributes()
    {
        bulletSpeed = 5.0f;
        shootDelay = 0.75f;
        
        if(increaseFireRate.fireratePowerUpActivated)
        {
            shootDelay /= 2f;
        }
        
        if(bulletSpeedPowerUp.bulletSpeedPowerUpActivated)
        {
            bulletSpeed *= 2f;
        }
    }
    

    public void UpdateShootDelay(float duration)
    {
        StartCoroutine(RevertShootDelayAfterDelay(duration));
    }

    private IEnumerator RevertShootDelayAfterDelay(float duration)
    {
        increaseFireRate.fireratePowerUpActivated = true;
        yield return new WaitForSeconds(duration);
        increaseFireRate.fireratePowerUpActivated = false;
    }
    
    
    public void UpdateBulletSpeed(float duration)
    {
        StartCoroutine(RevertBulletSpeed(duration));
    }

    private IEnumerator RevertBulletSpeed(float duration)
    {
        bulletSpeedPowerUp.bulletSpeedPowerUpActivated = true;
        yield return new WaitForSeconds(duration);
        bulletSpeedPowerUp.bulletSpeedPowerUpActivated = false;
    }
    

    public float getShotgunSpreadAngle()
    {
        return shotgunSpreadAngle;
    }

    public float getShootDelay()
    {
        return shootDelay;
    }

    public float getBulletSpeed()
    {
        return bulletSpeed;
    }
}
