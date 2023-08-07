using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Direction : MonoBehaviour
{
    private Vector3 target;
    public Camera mainCamera;
    public GameObject crosshair;
    
    void Update()
    {
        DirectionUserIsPointingAt();
        UpdateCrossHairPlacement();
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
