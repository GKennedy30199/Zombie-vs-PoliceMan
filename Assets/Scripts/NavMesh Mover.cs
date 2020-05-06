using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMover : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public virtual void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }
    public virtual void MoveTo(GameObject target)
    {
        MoveTo(target.transform.position);
    }
    public virtual void Stop()
    {
        agent.isStopped = true;
    }
    public Color DebugLineColor = Color.red;
    public virtual void OnDrawGizmos()
    {
        if(agent !=null)
        {
            if(agent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                for(int i=0; i < agent.path.corners.Length;i++)
                {
                    if (i + 1 < agent.path.corners.Length)
                    {
                        Gizmos.color = DebugLineColor;
                        Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
