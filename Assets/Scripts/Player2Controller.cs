using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform rotation;
    float xR = 0f;
    public CharacterController controller;
    public float SPD = 12f;
    private Vector2 Movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float Y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xR -= Y;
        xR = Mathf.Clamp(xR, -120f, 120f);
        transform.localRotation = Quaternion.Euler(xR, 0f, 0f);
        rotation.Rotate(Vector3.up * X);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * SPD * Time.deltaTime);


    }
}
