using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float MouseSense = 100f;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        Player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * MouseSense, 0);
    }
}
