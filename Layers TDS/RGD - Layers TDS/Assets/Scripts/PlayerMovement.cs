using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    public Camera cam;

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        Vector2 loodDir = mousePos - rb.position;
        float angle = Mathf.Atan2(loodDir.y, loodDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
