using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Life life;

    public void takeDamage()
    {
        life.damage(5);
    }
}
