using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IAmmoManager
{
    int AmmoInMagazine { get; }
    int TotalAmmo { get; }
}

public class AmmoUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI magazineAmmoText;
    public TextMeshProUGUI totalAmmoText;
    public TextMeshProUGUI reloadText;

    private Transform playerTransform;
    private Vector3 reloadTextOffset = new Vector3(0.4f, 1f, 0f);

    private IAmmoManager currentAmmoManager; // Reference to the current weapon's ammo manager

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SetCurrentAmmoManager(GameObject.FindGameObjectWithTag("Pistol").GetComponent<IAmmoManager>());
        UpdateAmmoText();
    }

    public void SetCurrentAmmoManager(IAmmoManager ammoManager)
    {
        currentAmmoManager = ammoManager;
    }

    public void UpdateAmmoText()
    {
        if (currentAmmoManager != null)
        {
            magazineAmmoText.text = "Magazine Ammo: " + currentAmmoManager.AmmoInMagazine;
            totalAmmoText.text = "Total Ammo: " + currentAmmoManager.TotalAmmo;
        }
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