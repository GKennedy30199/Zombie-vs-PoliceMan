using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float hp = 100f;
    public void DamageTaken (float amount)
    {
        hp -= amount;
        if(hp <=0f)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
