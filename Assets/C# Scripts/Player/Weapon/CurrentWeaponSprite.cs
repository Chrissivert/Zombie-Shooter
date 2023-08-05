using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeaponSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite pistolSprite;
    public Sprite shotgunSprite;
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
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            spriteRenderer.sprite = shotgunSprite;
        }
    }
}
