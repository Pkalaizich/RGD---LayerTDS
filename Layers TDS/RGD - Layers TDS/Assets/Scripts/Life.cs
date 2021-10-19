using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life;
    public void getDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
