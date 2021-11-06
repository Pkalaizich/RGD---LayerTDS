using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRing : MonoBehaviour
{
    public Ring ring;

    public void change()
    {
        ring.StartCoroutine("changeColour");
    }
}
