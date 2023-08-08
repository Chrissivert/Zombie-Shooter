using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Serialization;

public class PointAndShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;
    public GameObject bulletStart;
    public Direction direction;
    public CurrentWeaponAttributes currentWeaponAttributes;

    // [SerializeField] private AudioSource pistolShot;
    
    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());
        float shootTimer = 0f;
        shootTimer += Time.deltaTime;
    }
    public void Bullet(Vector2 direction)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());
        b.GetComponent<Rigidbody2D>().velocity = direction * currentWeaponAttributes.getBulletSpeed();
        // pistolShot.Play();
        
        Vector2 offset2 = direction * 0.01f;
        b.transform.position = new Vector2(b.transform.position.x + offset2.x, b.transform.position.y + offset2.y);
        Destroy(b, 3f);
    }
    
    public void SpreadBullets(Vector2 direction)
    {
        Bullet(direction);
        Quaternion spreadRotation1 = Quaternion.Euler(0.0f, 0.0f, currentWeaponAttributes.getShotgunSpreadAngle());
        Quaternion spreadRotation2 = Quaternion.Euler(0.0f, 0.0f, -currentWeaponAttributes.getShotgunSpreadAngle());
        Bullet(spreadRotation1 * direction);
        Bullet(spreadRotation2 * direction);
    }
    
    public void InstantiateGrenade()
    {
        Instantiate(grenadePrefab, transform.position, Quaternion.identity);
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