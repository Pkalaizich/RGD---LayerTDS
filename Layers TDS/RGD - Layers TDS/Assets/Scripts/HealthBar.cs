using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Life life;
    public Image fill;
    public Color original;
       
    public void SetHealth()
    {
        slider.value = life.life / life.maxLife;
        StartCoroutine("changeColour");
    }

    IEnumerator changeColour()
    {
        fill.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        fill.color = original;
    }
}
