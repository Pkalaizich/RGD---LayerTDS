using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody rb;

    Vector3 movement;
    Vector3 mousePos;
    //Vector3 objPos;

    public Camera cam;

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos.z = 0;
        //Vector3 objPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        Vector3 aux = new Vector3(rb.position.x, rb.position.y, 0);
        Vector3 loodDir = mousePos - aux;
        float angle = Mathf.Atan2(loodDir.y, loodDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //rb.MoveRotation
    }
}
