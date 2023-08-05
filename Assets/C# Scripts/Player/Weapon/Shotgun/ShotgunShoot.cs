using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    
    private float shootTimer = 0f;
    public PointAndShoot pointAndShoot;
    public AmmoManager ammoManager;
    public WeaponAttributes weaponAttributes;


    private void Update()
    {
        {
            shootTimer += Time.deltaTime;
            weaponAttributes.bulletSpeed = 10.0f;
            weaponAttributes.shootDelay = 0.75f;
            
            // if(increaseFireRate.fireratePowerUpActivated)
            // {
            //     weaponAttributes.shootDelay /= 2f;
            // }
            //
            // if(bulletSpeedPowerUp.bulletSpeedPowerUpActivated)
            // {
            //     weaponAttributes.bulletSpeed *= 2f;
            // }

        }
    }

    public void ShotgunShot()
    {
        if (ammoManager.ammoInMagazine > 0 && shootTimer >= weaponAttributes.getShootDelay())
        {
            pointAndShoot.ShootSpreadBullets(pointAndShoot.GetNormalizedVector2FromPlayerPosToCrosshair()); 
            ammoManager.ammoInMagazine--;
            Debug.Log("Magazinesize SHOTGUN" + ammoManager.magazineSize);
            Debug.Log("Ammo in magazine SHOTGUN" + ammoManager.ammoInMagazine);
            Debug.Log("Totalammo SHOTGUN" + ammoManager.totalAmmo);
            shootTimer = 0f;
        }
        
    }
}