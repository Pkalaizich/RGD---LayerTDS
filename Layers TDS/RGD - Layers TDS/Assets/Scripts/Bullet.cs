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
        AkSoundEngine.PostEvent("impacto_disparo", gameObject);
        Destroy(effect, 2f);
        Destroy(gameObject);
        Life life = collision.gameObject.GetComponent<Life>();
        if (life!=null)
        {
            life.damage(5);
        }
        if (collision.gameObject.tag =="DoorTrigger")
        {
            DoorTrigger dt = collision.gameObject.GetComponent<DoorTrigger>();
            dt.takeDamage();
        }
        if (collision.gameObject.tag =="Dummy")
        {
            Dummy dm = collision.gameObject.GetComponent<Dummy>();
            dm.takeDamage();
        }
        if (collision.gameObject.tag =="Ring")
        {
            Ring rg = collision.gameObject.GetComponent<Ring>();
            rg.destroyRing();
        }
        if (collision.gameObject.tag == "RingNormal")
        {
            NormalRing nr = collision.gameObject.GetComponent<NormalRing>();
            nr.change();
        }
        if (collision.gameObject.tag == "ShieldTrigger")
        {
            ShieldTrigger st = collision.gameObject.GetComponent<ShieldTrigger>();
            st.takeDamage();
        }
    }
    
}
