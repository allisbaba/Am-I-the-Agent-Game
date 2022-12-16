using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSecurity : MonoBehaviour
{
    NavMeshAgent agent;
    
    public Transform target;
    public GameObject securityCam;
    private Vector3 distanceToPosition;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        distanceToPosition = target.position - new Vector3(0.5f, 0, 0);

    }

    private void Update()
    {
       if(transform.position.x == distanceToPosition.x)
        {
            securityCam.SetActive(false);
        }
    }

    public void agentTransform()
    {
       
        agent.destination = distanceToPosition;

    }
}
