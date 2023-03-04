using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveTo : MonoBehaviour
{

    private GameObject NPC;

    private NavMeshAgent agent;

    private TrafficLightsHandler TLH;

    private float InitSpeed;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        NPC = GameObject.Find("NPC");

        TLH = NPC.GetComponent<TrafficLightsHandler>();

        InitSpeed = agent.speed;

        agent.destination = GiveNewDestination().transform.position;
    }


    void Update()
    {

        if (TLH.GetLight() == true)
        {
            agent.isStopped = false;

            if (agent.remainingDistance < 0.3)
            {
                agent.SetDestination(GiveNewDestination().transform.position);// give random gameobject destination 
            }

        }
        if (TLH.GetLight() == false)
        {

            if(gameObject.transform.position.x > -24 && gameObject.transform.position.x < -14)
            {
                //il est sur la route
                agent.isStopped = false;
                agent.speed = InitSpeed * 1.7f;
            }
            else
            {
                agent.isStopped = true;
                agent.speed = InitSpeed;
            }

             
               
            
        }
    }


    private GameObject GiveNewDestination()
    {
        if(transform.position.x < -19)
        {
            float val = Random.value;
            if(val < 0.3)
            {
                return GameObject.Find("Zone (4)");
            }
            else if (val < 0.7)
            {
                return GameObject.Find("Zone (5)");
            }
            else
            {
                return GameObject.Find("Zone (6)");
            }
        }
        else
        {
            float val = Random.value;
            if (val < 0.3)
            {
                return GameObject.Find("Zone (1)");
            }
            else if (val < 0.7)
            {
                return GameObject.Find("Zone (2)");
            }
            else
            {
                return GameObject.Find("Zone (3)");
            }
        }


    }


}
