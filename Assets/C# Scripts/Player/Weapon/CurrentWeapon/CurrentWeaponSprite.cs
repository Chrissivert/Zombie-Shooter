using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeaponSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite pistolSprite;
    public Sprite shotgunSprite;
    public string currentWeapon;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spriteRenderer.sprite = pistolSprite;
            SwitchToPistol();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            spriteRenderer.sprite = shotgunSprite;
            SwitchToShotgun();
        }
    }
    
    public string SwitchToPistol()
    {
        currentWeapon = "pistol";
        return this.currentWeapon;
    }
    
    public string SwitchToShotgun()
    {
        currentWeapon = "shotgun";
        return this.currentWeapon;
    }
}