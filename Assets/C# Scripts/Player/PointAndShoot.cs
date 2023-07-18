using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject currentWeapon;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public Direction direction;
    public GameObject grenade;

    private float originalShootDelay;
    public float bulletSpeed = 30.0f;
    private float shootTimer = 0f;
    public float shootDelay = 0.25f;
    public float spacingBetweenBullets = 0.3f;

    [SerializeField] private AudioSource pistolShot;
    
    void Start()
    {
        Cursor.visible = false;
        currentWeapon = GameObject.Find("pistol");
        //GameObject player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetRotationOfPlayerAndCrosshair());

        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= shootDelay)
        {
            if (currentWeapon == GameObject.Find("pistol"))
            {
                ShootSpreadBullets(GetNormalizedVector2FromPlayerPosToCrosshair());     
                shootTimer = 0f;
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
        
        float bulletSpacing = 0.2f; // Adjust this value to control the spacing
        Vector2 offset2 = direction * bulletSpacing;
        b.transform.position = new Vector2(b.transform.position.x + offset2.x, b.transform.position.y + offset2.y);
        
        Destroy(b, 3f);
    }
    
    void ShootSpreadBullets(Vector2 direction)
    {
        float spreadAngle = 60f;
        
        FireBullet(direction);
        Quaternion spreadRotation1 = Quaternion.Euler(0.0f, 0.0f, spreadAngle);
        Quaternion spreadRotation2 = Quaternion.Euler(0.0f, 0.0f, -spreadAngle);
        
        FireBullet(spreadRotation1 * direction);
        FireBullet(spreadRotation2 * direction);


        // Vector2 offset2 = CreateSpacingBetweenBullets(spacingBetweenBullets);
        // b.transform.position = new Vector2(b.transform.position.x + offset2.x, b.transform.position.y + offset2.y);
        
    }


    private Vector2 CreateSpacingBetweenBullets(float amountOfSpacing)
    {
        Vector2 offset = GetNormalizedVector2FromPlayerPosToCrosshair() * amountOfSpacing;
        return offset;
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





    public void UpdateShootDelay(float halfShootDelay, int duration)
    {
        originalShootDelay = shootDelay;
        shootDelay = halfShootDelay / 2f;
        if (shootDelay < 0.1f) {
            shootDelay = 0.1f;
        }
        StartCoroutine(RevertShootDelayAfterDelay(duration));
    }

    private IEnumerator RevertShootDelayAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        shootDelay = originalShootDelay;
    }
}