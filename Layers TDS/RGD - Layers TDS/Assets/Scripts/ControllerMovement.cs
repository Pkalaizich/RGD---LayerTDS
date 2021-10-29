using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    private static ControllerMovement instance;
    public static ControllerMovement Instance { get => instance; }

    public float moveSpeed = 5f;

    public CharacterController cc;

    Vector3 movement;
    Vector3 mousePos;
    
    public bool normalPlane = true;

    public Camera cam;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Update()
    {
        if(GameController.Instance.gameStart==true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos.z = 0;            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                mousePos = raycastHit.point;
            }
        }      

    }

    private void FixedUpdate()
    {
        if (GameController.Instance.gameStart == true)
        {
            cc.Move(movement * moveSpeed * Time.deltaTime);
            Vector3 aux = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Vector3 loodDir = mousePos - aux;
            float angle = Mathf.Atan2(loodDir.y, loodDir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
   
}
