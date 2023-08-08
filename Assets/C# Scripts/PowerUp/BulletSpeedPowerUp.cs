// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class BulletSpeedPowerUp : MonoBehaviour
// {
//     
//     public float bulletSpeedPowerUpDuration = 20f;
//     public bool bulletSpeedPowerUpActivated;
//     
//     private void OnCollisionStay2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             BulletSpeedPowerUpPlayer(collision.gameObject);
//             Destroy(gameObject);
//         }
//     }
//
//     private void BulletSpeedPowerUpPlayer(GameObject player)
//     {
//         WeaponAttributes weaponAttributes = player.GetComponent<WeaponAttributes>();
//         weaponAttributes.UpdateBulletSpeed(bulletSpeedPowerUpDuration);
//     }
//
//
//     public void UpdateBulletSpeed(float duration)
//     {
//         StartCoroutine(RevertBulletSpeed(duration));
//     }
//
//     private IEnumerator RevertBulletSpeed(float duration)
//     {
//         bulletSpeedPowerUp.bulletSpeedPowerUpActivated = true;
//         yield return new WaitForSeconds(duration);
//         bulletSpeedPowerUp.bulletSpeedPowerUpActivated = false;
//     }
// }
