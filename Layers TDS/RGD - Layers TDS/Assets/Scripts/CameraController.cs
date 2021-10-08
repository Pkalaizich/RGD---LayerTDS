using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator anim => GetComponent<Animator>();
    private bool normalCamera = true;
    public GameObject Player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (normalCamera)
            {
                anim.Play("SpiritualWorldCamera");
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 15);
            }
            else
            {                
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 15);
                anim.Play("NormalWorldCamera");
            }
            normalCamera = !normalCamera;
        }
    }
}
