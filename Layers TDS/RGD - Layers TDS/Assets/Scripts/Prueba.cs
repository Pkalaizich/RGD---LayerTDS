using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public GameObject Player;
    public SpriteRenderer sr;


    private void Awake()
    {
        sr = Player.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Color aux = sr.color;
            aux.a = 0.5f;
            sr.color = aux;
        }
    }
}
