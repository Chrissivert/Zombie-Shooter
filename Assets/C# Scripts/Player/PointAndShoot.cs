using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public Direction direction;
    public GameObject grenade;
    public CurrentWeaponSprite currentWeaponSprite;

    public float originalShootDelay;
    public float bulletSpeed = 30.0f;
    private float shootTimer = 0f;
    public float shootDelay = 0.25f;
    public float shotgunSpreadAngle = 15f;

    [SerializeField] private AudioSource pistolShot;
    
    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());

        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= shootDelay)
        {
            if (currentWeaponSprite.currentWeapon == "pistol")
            {
                FireBullet(GetNormalizedVector2FromPlayerPosToCrosshair());
                shootTimer = 0f;
                shootDelay = 0.25f;
                bulletSpeed = 30f;
            }

            if (currentWeaponSprite.currentWeapon == "shotgun")
            {
                ShootSpreadBullets(GetNormalizedVector2FromPlayerPosToCrosshair());
                shootTimer = 0f;
                shootDelay = 0.75f;
                bulletSpeed = 15f;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.I)) {
            ShootGrenade();
        }
    }
    void FireBullet(Vector2 direction)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        pistolShot.Play();
        
        Vector2 offset2 = direction * 0.01f;
        b.transform.position = new Vector2(b.transform.position.x + offset2.x, b.transform.position.y + offset2.y);
        Destroy(b, 3f);
    }
    
    void ShootSpreadBullets(Vector2 direction)
    {
        FireBullet(direction);
        Quaternion spreadRotation1 = Quaternion.Euler(0.0f, 0.0f, shotgunSpreadAngle);
        Quaternion spreadRotation2 = Quaternion.Euler(0.0f, 0.0f, -shotgunSpreadAngle);
        
        FireBullet(spreadRotation1 * direction);
        FireBullet(spreadRotation2 * direction);
    }

    private void ShootGrenade()
    {
        Instantiate(grenade, transform.position, Quaternion.identity);
    }

    private Vector3 GetVector3FromPlayerPosToCrossHair()
    {
        Vector3 difference = direction.DirectionUserIsPointingAt() - player.transform.position;
        return difference;
    }

    private Vector2 GetNormalizedVector2FromPlayerPosToCrosshair()
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





    // public void UpdateShootDelay(float duration)
    // {
    //     if (!isFireRateHalved)
    //     {
    //         originalShootDelay = shootDelay;
    //         shootDelay /= 2f;
    //     }
    //     shootDelay /= 2f;
    //     if (shootDelay < originalShootDelay/2f)
    //     {
    //         shootDelay = originalShootDelay/2f;
    //     }
    //     StartCoroutine(RevertShootDelayAfterDelay(duration));
    // }

    private IEnumerator RevertShootDelayAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        shootDelay = originalShootDelay;
    }
}