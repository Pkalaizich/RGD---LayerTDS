using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour
{
    public List<GameObject> triggers;
    public int destroyedTriggers;
    public GameObject shield;
    public float timeToRestoreShield=2f;
    private bool shieldDestroyed;
    private float restoreTimer;
    
    public void CheckTriggers()
    {
        destroyedTriggers = 0;
        foreach (GameObject trigger in triggers)
        {
            Debug.Log("hay: " + triggers.Count + " triggers");
            if (trigger.gameObject.activeSelf ==false)
            {
                destroyedTriggers += 1;
            }
        }
        if(destroyedTriggers >= triggers.Count-1)
        {
            shield.gameObject.SetActive(false);
            shieldDestroyed = true;
        }
    }

    private void FixedUpdate()
    {
        if (shieldDestroyed==true)
        {
            restoreTimer += Time.deltaTime;
            if (restoreTimer>=timeToRestoreShield)
            {
                RestoreShield();
            }
        }
    }

    public void RestoreShield()
    {
        shieldDestroyed = false;
        restoreTimer = 0;
        shield.gameObject.SetActive(true);
        foreach (GameObject trigger in triggers)
        {
            trigger.SetActive(true);
        }
    }
}
