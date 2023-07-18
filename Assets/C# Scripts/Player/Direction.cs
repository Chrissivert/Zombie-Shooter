using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Direction : MonoBehaviour
{
    public GameObject player;
    private Vector3 target;
    public GameObject bulletStart;
    public Camera mainCamera;
    public GameObject crosshair;
    
    void Update()
    {
        DirectionUserIsPointingAt();
        UpdateCrossHairPlacement();
        // UpdateBulletStartRotation();
    }

    public Vector3 DirectionUserIsPointingAt()
    {
        target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        return target;
    }

    void UpdateCrossHairPlacement()
    {
        crosshair.transform.position = new Vector2(target.x, target.y);
    }

    // void UpdateBulletStartRotation()
    // {
    //     Vector3 direction = DirectionUserIsPointingAt();
    //     float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //
    //     // Calculate the rotation around the x-axis
    //     float rotationX = Mathf.Atan2(direction.z, Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y)) * Mathf.Rad2Deg;
    //
    //     bulletStart.transform.rotation = Quaternion.Euler(rotationX, 0.0f, rotationZ);
    // }

}
