using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public GameObject grenade;
    public Direction direction;

    private float originalShootDelay;
    public float bulletSpeed = 30.0f;
    private float shootTimer = 0f;
    public float shootDelay = 0.25f;

    [SerializeField] private AudioSource pistolShot;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = direction.DirectionUserIsPointingAt() - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= shootDelay)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);

            shootTimer = 0f; // Reset the timer after firing
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            Instantiate(grenade, transform.position, Quaternion.identity);
        }
    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        pistolShot.Play();
        Destroy(b, 3f);
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