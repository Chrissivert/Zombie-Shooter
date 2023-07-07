using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Direction : MonoBehaviour
{
    public GameObject player;
    private Vector3 target;
    public Camera mainCamera;
    public GameObject crosshairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        crosshairs.transform.position = new Vector2(target.x, target.y);
    }
}
