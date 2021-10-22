using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public float life = 10;

    public void damage(float damage)
    {
        life -= damage;
        if (life<=0)
        {
            this.gameObject.SetActive(false);
            if (this.gameObject.tag =="Player")
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
