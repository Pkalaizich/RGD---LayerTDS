using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public AudioClip hittingSound;
    public AudioSource source;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        source.PlayOneShot(hittingSound);
        Destroy(effect, 2f);
        Destroy(gameObject, 0.1f);
        if(collision.gameObject.tag=="Player"|| collision.gameObject.tag == "Enemy")
        {
            Life aux = collision.gameObject.GetComponent<Life>();
            if (aux != null)
                aux.getDamage(1);
        }
    }
}
