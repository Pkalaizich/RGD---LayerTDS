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
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            mousePos = raycastHit.point;
        }

    }

    private void FixedUpdate()
    {
        cc.Move(movement * moveSpeed * Time.deltaTime);
        Vector3 aux = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 loodDir = mousePos - aux;
        float angle = Mathf.Atan2(loodDir.y, loodDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //rb.MoveRotation
    }

    //public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    //{
    //    Debug.Log("buscandomouse");
    //    Ray ray = Camera.main.ScreenPointToRay(screenPosition);
    //    Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
    //    float distance;
    //    xy.Raycast(ray, out distance);
    //    return ray.GetPoint(distance);
    //}
}
