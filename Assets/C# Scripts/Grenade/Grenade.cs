using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Grenade : MonoBehaviour
{

    private Vector3 targetPos;
    public Player CursorMovement;

    public float greneadeSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        CursorMovement.CrosshairPlacement();
    }

    // Update is called once per frame
    void Update()
    {
        if(greneadeSpeed > 0)
        {
            greneadeSpeed -= Random.Range(.1f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, greneadeSpeed * Time.deltaTime);
        }else if(greneadeSpeed < 0)
        {
            greneadeSpeed = 0;
        }   
    }
}
