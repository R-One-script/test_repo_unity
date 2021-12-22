using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform orientation;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    float movementMultiplier = 10f;

    private float xMovement;
    private float yMovement;

    [Header("Drag")]
    [SerializeField] float groundDrag = 6f;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void GetInput()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * yMovement + orientation.right * xMovement;
    }

    void ControlDrag()
    {
        rb.drag = groundDrag;
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }
    void Update()
    {
        GetInput();
        ControlDrag();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
