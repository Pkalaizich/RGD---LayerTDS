using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public AudioClip hittingSound;
    public AudioSource source;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //source.PlayOneShot(hittingSound);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
    
}
