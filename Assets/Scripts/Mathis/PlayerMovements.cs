using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody rb;
    private Vector3 velocity = Vector3.zero;

    public Animator animator;
    public SpriteRenderer spriteRenderer;


    void FixedUpdate()
    {
        Vector3 deplacement = new Vector3(0, 0, 0);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float depthMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if (horizontalMovement > 0 && depthMovement > 0)
        {
           deplacement = new Vector3(horizontalMovement / 2, 0, depthMovement / 2);
        } else
        {
            deplacement = new Vector3(horizontalMovement, 0, depthMovement);
        }

        Flip(rb.velocity.x);
        MovePlayer(deplacement);
        float PPVelocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z);
        animator.SetFloat("speed", PPVelocity);
       
    }

    void MovePlayer(Vector3 _movement)
    {
        Vector3 targetVelocity = _movement;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
 
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }

        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
