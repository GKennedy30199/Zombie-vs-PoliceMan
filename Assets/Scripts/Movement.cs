using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] TargetLoc;
    private float SPD=5;
    private int CurrentLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != TargetLoc[CurrentLoc].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, TargetLoc[CurrentLoc].position, SPD * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else CurrentLoc = (CurrentLoc + 1) % TargetLoc.Length;
    }
}
