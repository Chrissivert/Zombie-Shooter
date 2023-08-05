using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PistolShoot : MonoBehaviour
{
    
    private float shootTimer = 0f;
    public PointAndShoot pointAndShoot;
    public AmmoManager ammoManager;
    public AmmoUIUpdater ammoUIUpdater;
    public WeaponAttributes weaponAttributes;

    private void Update()
    {
        {
            shootTimer += Time.deltaTime;
        }
    }

    public void PistolShot()
    {
        if (ammoManager.ammoInMagazine > 0 && shootTimer >= weaponAttributes.getShootDelay())
        {
            pointAndShoot.FireBullet(pointAndShoot.GetNormalizedVector2FromPlayerPosToCrosshair()); 
            ammoManager.ammoInMagazine--;
            ammoUIUpdater.UpdateAmmoText();
            
            shootTimer = 0f;
        }
        
    }
}
