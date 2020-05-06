using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Controller : MonoBehaviour
{
    public int Maxhealth = 100;
    public int CurrentHealth;
    public float Damage = 10f;
    public float range = 20f;
    public CharacterController controller;
    public float SPD = 12f;
    public float Gravity = -9.81f;
    Vector3 velocity;
    public Camera cam;
    public Transform GroundCheck;
    public float groundDis = 0.4f;
    public LayerMask ground;
    bool Grounded;
    public float Jump = 3f;
    public Healthbar healthbar;
    private void Start()
    {
        CurrentHealth = Maxhealth;
        healthbar.SetMaxHealth(Maxhealth);
    }
    private void Update()
    {
        
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 Moving = transform.right * X + transform.forward * Z;
        controller.Move(Moving*SPD*Time.deltaTime);
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
        Grounded = Physics.CheckSphere(GroundCheck.position,groundDis,ground);
        if(Grounded&&velocity.y<0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump")&& Grounded)
        {
            velocity.y = Mathf.Sqrt(Jump * -2f * Gravity);
        }

        //Shlash
        if(Input.GetButtonDown("Fire1"))
        {
            Slashing();
        }
        void Slashing()
        {
            RaycastHit slash;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out slash, range))
            {
                Debug.Log(slash.transform.name);


                EnemyHealth EnemyHp = slash.transform.GetComponent<EnemyHealth>();
                if(EnemyHp !=null)
                {
                    EnemyHp.DamageToHealth(Damage);
                }
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }
    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthbar.SetHealth(CurrentHealth);
    }
}
