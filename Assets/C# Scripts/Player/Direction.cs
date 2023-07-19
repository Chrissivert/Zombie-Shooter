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

}
