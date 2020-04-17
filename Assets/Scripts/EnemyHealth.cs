using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public float Hp = 50f;
    public void DamageToHealth(float Number)
    {
        Hp -= Number;
        if(Hp <= 0f)
        {
            Death();
        }

    }
    void Death()
    {
        Destroy(gameObject);
        
    }
}
