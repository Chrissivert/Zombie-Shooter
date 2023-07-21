using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Serialization;

public class PointAndShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public Direction direction;
    public GameObject grenade;
    public CurrentWeaponSprite currentWeaponSprite;
    public WeaponAttributes weaponAttributes;
    public PistolShoot pistolShoot;
    public ShotgunShoot shotgunShoot;
    
    private float shootTimer = 0f;

    [SerializeField] private AudioSource pistolShot;
    
    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (currentWeaponSprite.currentWeapon == "pistol")
            {
                weaponAttributes.PistolAttributes();
                pistolShoot.PistolShot();
            }

            if (currentWeaponSprite.currentWeapon == "shotgun")
            {
                weaponAttributes.ShotgunAttributes();
                shotgunShoot.ShotgunShot();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.I)) {
            ShootGrenade();
        }
    }
    public void FireBullet(Vector2 direction)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());
        b.GetComponent<Rigidbody2D>().velocity = direction * weaponAttributes.getBulletSpeed();
        pistolShot.Play();
        
        Vector2 offset2 = direction * 0.01f;
        b.transform.position = new Vector2(b.transform.position.x + offset2.x, b.transform.position.y + offset2.y);
        Destroy(b, 3f);
    }
    
    public void ShootSpreadBullets(Vector2 direction)
    {
        FireBullet(direction);
        Quaternion spreadRotation1 = Quaternion.Euler(0.0f, 0.0f, weaponAttributes.getShotgunSpreadAngle());
        Quaternion spreadRotation2 = Quaternion.Euler(0.0f, 0.0f, -weaponAttributes.getShotgunSpreadAngle());
        
        FireBullet(spreadRotation1 * direction);
        FireBullet(spreadRotation2 * direction);
    }

    private void ShootGrenade()
    {
        Instantiate(grenade, transform.position, Quaternion.identity);
    }

    public Vector3 GetVector3FromPlayerPosToCrossHair()
    {
        Vector3 difference = direction.DirectionUserIsPointingAt() - player.transform.position;
        return difference;
    }

    public Vector2 GetNormalizedVector2FromPlayerPosToCrosshair()
    {
        float getLengthOfVector = GetVector3FromPlayerPosToCrossHair().magnitude;
        Vector2 directionVector = GetVector3FromPlayerPosToCrossHair() / getLengthOfVector;
        directionVector.Normalize();
        return directionVector;
    }

    private float GetRotationOfPlayerAndCrosshair()
    {
        float rotationZ = Mathf.Atan2(GetVector3FromPlayerPosToCrossHair().y, GetVector3FromPlayerPosToCrossHair().x) * Mathf.Rad2Deg;
        return rotationZ;
    }
}