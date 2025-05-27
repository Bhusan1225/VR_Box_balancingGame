using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;

public class ForkliftController : MonoBehaviour
{



    public InputActionReference rightTrigger; // Forward (right hand)
    public InputActionReference leftTrigger;  // Backward (left hand)
    public XRKnob knob;                       // Steering knob
    public float moveSpeed = 5f;
    public float rotationSpeed = 50f;
  

    private Rigidbody rb;
    private bool moveForward = false;
    private bool moveBackward = false;

    private bool isReverseGearOn = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (!isReverseGearOn)
        {
            // Right trigger = forward
            if (rightTrigger.action.WasPressedThisFrame())
                moveForward = true;
            if (rightTrigger.action.WasReleasedThisFrame())
                moveForward = false;

            // Left trigger = backward
            if (leftTrigger.action.WasPressedThisFrame())
                moveForward = true;
            if (leftTrigger.action.WasReleasedThisFrame())
                moveForward = false;
        }
        else
        {
            // Right trigger = forward
            if (rightTrigger.action.WasPressedThisFrame())
                moveBackward = true;
            if (rightTrigger.action.WasReleasedThisFrame())
                moveBackward = false;

            // Left trigger = backward
            if (leftTrigger.action.WasPressedThisFrame())
                moveBackward = true;
            if (leftTrigger.action.WasReleasedThisFrame())
                moveBackward = false;
        }


    }

    void FixedUpdate()
    { 
        Vector3 moveDirection = Vector3.zero;

        if (!isReverseGearOn && moveForward == true)
            moveDirection = transform.forward;
        else if (isReverseGearOn && moveBackward == true)
            moveDirection = -transform.forward;

        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

            // Steering
            float steerInput = (knob.value - 0.5f) * 2f; // -1 to 1
            float rotation = steerInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * turnOffset);
        }
    }
}

