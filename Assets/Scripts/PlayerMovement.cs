using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    Animator animator;
    private Vector3 lastPosition;

    private float idleTimer = 0f;
    private float idleThreshold = 10f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        GroundCheck();
        Move();
        Jump();
        Fall();
        UpdateAnimation();
        Shooting();
        Run();
        StandEffect();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("nhay", false);
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        Run();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("nhay", true);
        }
    }

    void Fall()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateAnimation()
    {
        float distanceMoved = Vector3.Distance(lastPosition, transform.position);
        bool isMoving = distanceMoved > 0.01f;
        animator.SetBool("dibo", isMoving);
        lastPosition = transform.position;
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("ban", true);
        }
        else
        {
            animator.SetBool("ban", false);
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("chay", true);
        }
        else
        {
            animator.SetBool("chay", false);
        }
    }

    void StandEffect()
    {
        if (controller.velocity.magnitude < 0.01f) // If the player is nearly stationary
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleThreshold)
            {
                // Change to idle animation here
                animator.SetBool("hieuungdungyen", true);
            }
        }
        else
        {
            // Reset idle timer if the player moves
            idleTimer = 0f;
            animator.SetBool("hieuungdungyen", false);
        }
    }

}

