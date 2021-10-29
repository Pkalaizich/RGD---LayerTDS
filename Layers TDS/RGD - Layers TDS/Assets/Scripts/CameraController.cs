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
    public GameObject normalBackground;
    private Collider box;
    public float newAlpha = 0.5f;
    public GameObject Dummy;
    //private SpriteRenderer sr;

    private void Awake()
    {
        box = normalBackground.gameObject.GetComponent<BoxCollider>();
        //sr = Player.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (GameController.Instance.gameStart == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (normalCamera)
                {
                    CharacterController cc = Player.GetComponent<CharacterController>();
                    cc.enabled = false;
                    //anim.Play("SpiritualWorldCamera");
                    previousLocation = Player.transform.position;
                    Dummy.transform.position = Player.transform.position;
                    Dummy.transform.rotation = Player.transform.rotation;
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + distanceBeetweenPlanes);
                    Dummy.SetActive(true);
                    cc.enabled = true;
                    Color aux = Player.GetComponent<SpriteRenderer>().color;
                    aux.a = newAlpha;
                    Player.GetComponent<SpriteRenderer>().color = aux;
                    //dot.SetActive(false);
                }
                else
                {
                    CharacterController cc = Player.GetComponent<CharacterController>();
                    cc.enabled = false;
                    Dummy.SetActive(false);
                    Player.transform.position = previousLocation;
                    //Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 15);
                    //anim.Play("NormalWorldCamera");
                    cc.enabled = true;
                    Color aux = Player.GetComponent<SpriteRenderer>().color;
                    aux.a = 1;
                    Player.GetComponent<SpriteRenderer>().color = aux;
                    //dot.SetActive(true);
                }
                normalCamera = !normalCamera;
                ControllerMovement.Instance.normalPlane = !ControllerMovement.Instance.normalPlane;
                box.enabled = !box.enabled;
            }
        }
        
    }
}
