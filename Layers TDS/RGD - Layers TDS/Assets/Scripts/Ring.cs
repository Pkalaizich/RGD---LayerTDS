using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameObject normalPlaneRing;
    private SpriteRenderer sr;
    private Color aux;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        aux = sr.color;
    }
    public void destroyRing()
    {
        normalPlaneRing.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public IEnumerator changeColour()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sr.color = aux;
    }
}
