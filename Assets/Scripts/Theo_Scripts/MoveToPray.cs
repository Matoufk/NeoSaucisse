using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveToPray : MonoBehaviour
{

    private NavMeshAgent agent;

    private float InitSpeed;
    private float oldTransX = 0;
    private float oldTransY = 0;

    public Camera cam;
    public SpriteRenderer spriteRenderer;
    public Rigidbody rb;
    public Animator animator;
    private float PNJVelocity = 0;

    float x;
    float z;

    public bool praying = false;

    void Start()
    {
        Debug.Log("Start");
        agent = GetComponent<NavMeshAgent>();

        InitSpeed = agent.speed;

        agent.destination = GiveNewDestination().transform.position;
    }


    void Update()
    {

        x = gameObject.transform.position.x;
        z = gameObject.transform.position.z;


        if (agent.remainingDistance < 0.3)
        {
            // reached goal
            agent.SetDestination(GiveNewDestination().transform.position); // give random gameobject destination 

            if (x > -5 && x < 3 && z > -2 && z < 10 && praying == false)
            {
                // Zone de prières
                praying = true;
                agent.isStopped = true;

            }

        }

        if (praying == true)
        {
            // Condition de fin de priere
            float val = Random.value;

            if (val < 0.002)
            {
                agent.isStopped = false;
                praying = false;
                agent.SetDestination(GiveNewDestination().transform.position); // give random gameobject destination
            }

        }



        // Design

        this.transform.LookAt(cam.transform);

        if (oldTransX > this.transform.position.x + 0.04)
        {
            spriteRenderer.flipX = false;
        }
        else if (oldTransX < this.transform.position.x - 0.04)
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
        Debug.Log(PNJVelocity);
        animator.SetFloat("speed", PNJVelocity);

        oldTransX = this.transform.position.x;
        oldTransY = this.transform.position.y;
    }


    private GameObject GiveNewDestination()
    {
        
        float val = Random.value;

        if (val < 0.15)
        {
            return GameObject.Find("Zone_pray (4)");
        }
        else if (val < 0.3)
        {
            return GameObject.Find("Zone_pray (5)");
        }
        else if (val < 0.45)
        {
            return GameObject.Find("Zone_pray (6)");
        }
        else if (val < 0.6)
        {
            return GameObject.Find("Zone_pray (1)");
        }
        else if (val < 0.75)
        {
            return GameObject.Find("Zone_pray (2)");
        }
        else
        {
            return GameObject.Find("Zone_pray (3)");
        }
        

    }
    


}
