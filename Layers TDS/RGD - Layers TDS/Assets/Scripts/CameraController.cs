using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator anim => GetComponent<Animator>();
    private bool normalCamera = true;
    public GameObject Player;
    private Vector3 previousLocation;
    public float distanceBeetweenPlanes = 5;
    //public GameObject dot;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (normalCamera)
            {
                CharacterController cc = Player.GetComponent<CharacterController>();
                cc.enabled = false;
                //anim.Play("SpiritualWorldCamera");
                previousLocation = Player.transform.position;
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + distanceBeetweenPlanes);
                cc.enabled = true;
                //dot.SetActive(false);
            }
            else
            {
                CharacterController cc = Player.GetComponent<CharacterController>();
                cc.enabled = false;
                Player.transform.position = previousLocation;
                //Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 15);
                //anim.Play("NormalWorldCamera");
                cc.enabled = true;
                //dot.SetActive(true);
            }
            normalCamera = !normalCamera;
            ControllerMovement.Instance.normalPlane = !ControllerMovement.Instance.normalPlane;
        }
    }
}
