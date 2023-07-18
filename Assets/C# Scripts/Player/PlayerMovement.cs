using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float originalMoveSpeed;
    public float moveSpeed = 5f;
    public float maxAllowedMoveSpeed = 100f;
    public float test = 0f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test");
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void UpdateMovementSpeed(float moveSpeedMultiplier, int duration)
    {
        originalMoveSpeed = moveSpeed;
        moveSpeed = moveSpeed * moveSpeedMultiplier;
        if (moveSpeed > maxAllowedMoveSpeed)
        {
            moveSpeed = maxAllowedMoveSpeed;
        }

        StartCoroutine(RevertMovementSpeed(duration));
    }

    private IEnumerator RevertMovementSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);
        originalMoveSpeed = moveSpeed;
    }
}
