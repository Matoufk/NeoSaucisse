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
    private float oldTransX = 0;
    private float oldTransY = 0;

    public Camera cam;
    public SpriteRenderer spriteRenderer;
    public Rigidbody rb;
    public Animator animator;
    private float PNJVelocity = 0;

    void Start()
    {
        //Debug.Log("Start");
        agent = GetComponent<NavMeshAgent>();

        NPC = GameObject.Find("PNJ");

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

            if(gameObject.transform.position.x < -14 && gameObject.transform.position.x > -24)
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
        this.transform.LookAt(cam.transform);

        if (oldTransX > this.transform.position.x + 0.02)
        {
            spriteRenderer.flipX = false;
        }
        else if (oldTransX < this.transform.position.x - 0.02)
        {
            spriteRenderer.flipX = true;
        }


        if (agent.isStopped == true)
        {
            PNJVelocity = 0;
        }
        else
        {
            PNJVelocity = 1;
        }
        //Debug.Log(PNJVelocity);
        animator.SetFloat("speed", PNJVelocity);

        oldTransX = this.transform.position.x;
        oldTransY = this.transform.position.y;
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
