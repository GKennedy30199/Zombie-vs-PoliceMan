using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooting : MonoBehaviour
{
    public float Dmg = 10f;
    public float range = 100f;
    public Camera Player2Cam;
    public ParticleSystem Gunfire;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            RaycastShooting();
        }

    }
    void RaycastShooting()
    {
        Gunfire.Play();
        RaycastHit ShotAt;
       if( Physics.Raycast(Player2Cam.transform.position,Player2Cam.transform.forward,out ShotAt,range))
        {
            Debug.Log(ShotAt.transform.name);
            Damage damage = ShotAt.transform.GetComponent<Damage>();
            if(damage!=null)
            {
                damage.DamageTaken(Dmg);
            }
        }
    }

}
