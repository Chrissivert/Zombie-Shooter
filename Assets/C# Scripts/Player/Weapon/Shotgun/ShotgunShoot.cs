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
        }
    }
    
    public void ShotgunShot()
    {
        if (ammoManager.ammoInMagazine > 0 && shootTimer >= weaponAttributes.getShootDelay())
        {
            pointAndShoot.ShootSpreadBullets(pointAndShoot.GetNormalizedVector2FromPlayerPosToCrosshair()); 
            ammoManager.ammoInMagazine--;
            shootTimer = 0f;
        }
    }
}