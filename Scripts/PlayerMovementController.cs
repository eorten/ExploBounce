using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpforce = 25;
    [SerializeField] private float accelerationSpeed = 0.1f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float size = 0.5f;
    [SerializeField] private LayerMask tileLayer;

    private Rigidbody2D rb;
    private float acceleration;
    private bool grounded;

    private Vector2 checkpointPos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //EventManager.Current.PlayerGroundedChange(grounded); //Alt stopper :(
        SetAcceleration();
        Move();
        GroundedCheck();
        WalkingCheck();
    }

    private void WalkingCheck()
    {
        if (rb.velocity.magnitude > 0 && grounded)
        {
            EventManager.Current.PlayerWalking(true);
        }
        else
        {
            EventManager.Current.PlayerWalking(false);

        }
    }

    private void GroundedCheck()
    {
        bool lastGrounded = grounded;
        grounded = Physics2D.OverlapCircleAll(transform.position + offset, size, tileLayer).Length > 0;

        if (lastGrounded != grounded)
        {
            print("Groundedchange");
            EventManager.Current.PlayerGroundedChange(grounded);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + offset, size);
    }
    public void MoveToCheckpoint()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(checkpointPos.x, checkpointPos.y, transform.position.z);
    }

    public void SetCheckPoint(Vector2 newPos)
    {
        checkpointPos = newPos;
    }

    private void Move()
    {
        if (grounded)
        {

            rb.velocity = Vector2.right * acceleration * speed;
        }
        /*
        else
        {
            float yVel = rb.velocity.y;
            rb.velocity = new Vector2(acceleration * speed, yVel);
        }*/

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            float xVel = rb.velocity.x;
            rb.velocity = new Vector2(xVel, jumpforce);
        }
    }

    private void SetAcceleration()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            acceleration += Input.GetAxisRaw("Horizontal") * accelerationSpeed;
        }
        else
        {
            if (acceleration > 0)
            {
                acceleration -= accelerationSpeed;
                if (acceleration < 0)
                {
                    acceleration = 0;
                }
            }
            if (acceleration < 0)
            {
                acceleration += accelerationSpeed;
                if (acceleration > 0)
                {
                    acceleration = 0;
                }
            }
        }
        acceleration = Mathf.Clamp(acceleration, -1, 1);
    }

}
