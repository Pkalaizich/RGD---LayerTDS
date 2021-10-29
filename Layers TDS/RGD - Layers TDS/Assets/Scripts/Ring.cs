using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameObject normalPlaneRing;
    public void destroyRing()
    {
        normalPlaneRing.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
