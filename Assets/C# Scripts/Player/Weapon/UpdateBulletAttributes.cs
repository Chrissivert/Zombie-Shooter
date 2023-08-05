using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBulletAttributes : MonoBehaviour
{
    public IncreaseFireRate increaseFireRate;
    public BulletSpeedPowerUp bulletSpeedPowerUp;

    private void Start()
    {
        increaseFireRate.fireratePowerUpActivated = false;
        bulletSpeedPowerUp.bulletSpeedPowerUpActivated = false;
    }

    private void Update()
    {
        if (increaseFireRate.fireratePowerUpActivated)
        {
            UpdateShootDelay(10f);
        }
        
        if (bulletSpeedPowerUp.bulletSpeedPowerUpActivated)
        {
            UpdateBulletSpeed(10f);
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
}
