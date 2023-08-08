using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Shoot shoot;
    public CurrentWeaponSprite currentWeaponSprite;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            if (currentWeaponSprite.currentWeapon == "pistol")
            {
                shoot.PistolShot();
            }

            if (currentWeaponSprite.currentWeapon == "shotgun")
            {
                shoot.ShotgunShot();
            }
            
            if (currentWeaponSprite.currentWeapon == "grenade")
            {
                shoot.GrenadeShot();
            }
            
        }
    }
}