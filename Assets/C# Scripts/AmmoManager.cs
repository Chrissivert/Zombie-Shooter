using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmmoManager : MonoBehaviour
{
    public int magazineSize;
    public int ammoInMagazine;
    public int totalAmmo;
    public AmmoUIUpdater ammoUIUpdater;


    public void SetAmmoInMagazine(int ammo)
    {
        ammoInMagazine = ammo;
    }

    public int GetAmmoInMagazine()
    {
        return ammoInMagazine;
    }

    public void SetTotalAmmo(int amount)
    {
        totalAmmo = amount;
    }

    public int GetTotalAmmo()
    {
        return totalAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        
        if (ammoInMagazine <= 0)
        {
            ammoUIUpdater.ShowReloadText();
        }
        else
        {
            ammoUIUpdater.HideReloadText();   
        }

        if (totalAmmo == 0)
        {
            Debug.Log("No more bullets");
        }
    }

    private void Reload()
    {
        if (totalAmmo > 0)
        {
            int ammoNeeded = magazineSize - ammoInMagazine;
            if (totalAmmo >= ammoNeeded)
            {
                totalAmmo -= ammoNeeded;
                ammoInMagazine += ammoNeeded;
            }
            else
            {
                ammoInMagazine += totalAmmo;
                totalAmmo = 0;
            }
        }
    }
}
