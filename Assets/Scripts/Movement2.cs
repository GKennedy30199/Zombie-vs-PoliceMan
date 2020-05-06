using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : NavMeshMover
{
    public string TagToTrack = "Player";
    GameObject trackedPlayer;
    public float TrackDistance = 2;
    // Start is called before the first frame update
    public override void Start()
    {
        trackedPlayer = GameObject.FindGameObjectWithTag(TagToTrack);
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(trackedPlayer!=null)
        {
            if(Vector3.Distance(transform.position,trackedPlayer.transform.position)<=TrackDistance)
            MoveTo(trackedPlayer);
        }
    }
    public override void OnDrawGizmos()
    {
        Gizmos.color = DebugLineColor;
        Gizmos.DrawWireSphere(transform.position, TrackDistance);
        base.OnDrawGizmos();
    }
}
