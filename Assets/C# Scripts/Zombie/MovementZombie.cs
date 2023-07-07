using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementZombie : MonoBehaviour
{
    private Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    private void Update()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 direction = playerPos - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
