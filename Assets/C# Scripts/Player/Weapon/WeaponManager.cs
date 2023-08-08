using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Dictionary<WeaponType, IWeaponAttributes> weaponAttributesDictionary;
    public WeaponType selectedWeapon;
    public CurrentWeaponAttributes currentWeaponAttributes;

    private void Start()
    {
        InitializeAttributes();
    }

    void InitializeAttributes()
    {
        weaponAttributesDictionary[WeaponType.Pistol] =  new PistolAttributes();
        weaponAttributesDictionary[WeaponType.Shotgun] = new ShotgunAttributes();
    }

    private void Update()
    {
        IWeaponAttributes attributes = weaponAttributesDictionary[selectedWeapon];

        if (Input.GetKeyDown(KeyCode.N))
        {
            selectedWeapon = WeaponType.Pistol;
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            selectedWeapon = WeaponType.Shotgun;
        }

        if (selectedWeapon == WeaponType.Shotgun)
        {
            currentWeaponAttributes.setBulletSpeed(attributes.getBulletSpeed());
            currentWeaponAttributes.setShootDelay(attributes.getShootDelay());
            // currentWeaponAttributes.setShotgunSpreadAngle(attributes.getShotgunSpreadAngle());
        }
    }
}


public enum WeaponType
{
    Pistol,
    Shotgun,
}