using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : DinamicActor
{
    [SerializeField] private Camera mainCamera;

    private PlayerController input;
    private Animator anim;
    private Rigidbody rb;
    private RagdollController rc;

    private void Awake()
    {
        input = new PlayerController();
        input.Enable();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rc = GetComponent<RagdollController>();
    }

    private void Start()
    {
        currentMoveSpeed = defaultMoveSpeed;
        //rc.EnableAnimator();
        //GetComponent<CapsuleCollider>().enabled = true;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 directionInput = input.Main.Move.ReadValue<Vector2>();

        Vector3 movementDirection = new Vector3(directionInput.x, 0, directionInput.y);

        movementDirection = Quaternion.AngleAxis(mainCamera.transform.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * 50f * Time.deltaTime);
        }

        Vector3 newVelocity;

        if (input.Main.Sprint.ReadValue<float>() > 0f) 
        {
            newVelocity = movementDirection * currentMoveSpeed * sprintMultiplier * 50f * Time.deltaTime;
        }
        else
        {
            newVelocity = movementDirection * currentMoveSpeed * 50f * Time.deltaTime;
        }

        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;

        anim.SetFloat("Speed", rb.velocity.magnitude, 0.1f, Time.deltaTime);
    }
}

