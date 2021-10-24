using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float hitsToOpen=1;
    private float currentDamage=0;
    public GameObject doorToOpen;

    
    public void takeDamage()
    {
        currentDamage += 1;
        if (currentDamage >= hitsToOpen)
        {
            doorToOpen.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
