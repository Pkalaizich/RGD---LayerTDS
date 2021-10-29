using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    public BossShield bossShield;
    public void takeDamage()
    {
        bossShield.CheckTriggers();
        this.gameObject.SetActive(false);
    }
}
