using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Life : MonoBehaviour
{
    public float life = 10;
    public float maxLife = 10;
    public HealthBar hb;

    public void damage(float damage)
    {
        life -= damage;
        if (this.gameObject.tag =="Player")
        {
            hb.SetHealth();
        }
        if (life<=0)
        {
            this.gameObject.SetActive(false);
            if (this.gameObject.tag =="Player")
            {
                GameController.Instance.gameOver("Perdiste");                 
            }
            if(this.gameObject.tag=="Enemy")
            {
                GameController.Instance.enemiesDestroyed += 1;
                if(GameController.Instance.enemiesDestroyed>=GameController.Instance.totalEnemies)
                {
                    GameController.Instance.gameOver("Ganaste");
                }
            }
        }
    }
}
