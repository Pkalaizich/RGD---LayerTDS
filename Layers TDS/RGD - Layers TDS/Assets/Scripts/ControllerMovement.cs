using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public CharacterController cc;

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
        cc.Move(movement * moveSpeed * Time.deltaTime);
        Vector3 aux = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Vector3 loodDir = mousePos - aux;
        float angle = Mathf.Atan2(loodDir.y, loodDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //rb.MoveRotation
    }
}
