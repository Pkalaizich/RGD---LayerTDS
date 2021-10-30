using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Life life;
       
    public void SetHealth()
    {
        slider.value = life.life / life.maxLife;
    }
}
