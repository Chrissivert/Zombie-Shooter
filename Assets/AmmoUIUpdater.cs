using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUIUpdater : MonoBehaviour
{
    
    public TextMeshProUGUI magazineAmmoText;
    public TextMeshProUGUI totalAmmoText;
    public AmmoManager ammoManager;
    public TextMeshProUGUI reloadText;
    private Transform playerTransform;
    private Vector3 reloadTextOffset = new Vector3(0.4f, 1f, 0f);

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        magazineAmmoText.text = "Magazine Ammo: " + ammoManager.ammoInMagazine;
        totalAmmoText.text = "Total Ammo: " + ammoManager.totalAmmo;
    }
    
    public void ShowReloadText()
    {
        reloadText.rectTransform.position = Camera.main.WorldToScreenPoint(playerTransform.position + reloadTextOffset);
        reloadText.gameObject.SetActive(true);
        
    }
    
    public void HideReloadText()
    {
        reloadText.gameObject.SetActive(false);
    }
}
