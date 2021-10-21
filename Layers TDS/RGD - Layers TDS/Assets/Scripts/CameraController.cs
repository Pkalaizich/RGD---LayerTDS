using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator anim => GetComponent<Animator>();
    private bool normalCamera = true;
    public GameObject Player;
    private Vector3 previousLocation;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (normalCamera)
            {
                anim.Play("SpiritualWorldCamera");
                previousLocation = Player.transform.position;
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 15);
            }
            else
            {
                Player.transform.position = previousLocation;
                //Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 15);
                anim.Play("NormalWorldCamera");
            }
            normalCamera = !normalCamera;
        }
    }
}
