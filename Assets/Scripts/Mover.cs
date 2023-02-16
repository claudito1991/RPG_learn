
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
       // agent.SetDestination(target.position);
        // if(Input.GetMouseButton(0))
        // {
        //     
        // }

        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }

        UpdateAnimation();



    }

    private void UpdateAnimation()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float speed = localVelocity.z;

        GetComponent<Animator>().SetFloat("forwardSpeed",speed);
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if(hasHit)
        {
            agent.SetDestination(hit.point);
        }
        
    }
}
