using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody rb;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float depthMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 deplacement = new Vector3(horizontalMovement, 0, depthMovement);
        
        MovePlayer(deplacement);
       
    }

    void MovePlayer(Vector3 _movement)
    {
        Vector3 targetVelocity = _movement;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
 
    }
}
