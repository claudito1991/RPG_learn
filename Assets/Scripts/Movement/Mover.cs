
using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement

{
    public class Mover : MonoBehaviour
{
    private NavMeshAgent agent;
    Ray lastRay;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
    
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float speed = localVelocity.z;
    
        GetComponent<Animator>().SetFloat("forwardSpeed",speed);
    }

    public void StartMoveAction(Vector3 destination)
    {
        GetComponent<ActionScheduler>().StartAction(this);
        GetComponent<Fighter>().Cancel();
        MoveTo(destination);
    }

    public void MoveTo(Vector3 destination)
    {
    
        agent.SetDestination(destination);
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
    }
}
}

