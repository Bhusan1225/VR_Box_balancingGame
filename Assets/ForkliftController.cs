using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;

public class ForkliftController : MonoBehaviour
{
    /*public WheelCollider[] wheels =new WheelCollider[4];
    public InputActionReference trigger;
    public XRKnob knob;

    public bool isPressed = false;
    public float motorTorque ;
    public float brakeTorque ;
    public float steeringMax ;

    void Start()
    {
        // Optional: Initialization if needed
    }

    private void Update()
    {
        // Check if trigger was pressed this frame
        if (trigger.action.WasPressedThisFrame())
        {
            //isPressed = true;
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 0;
                wheels[i].motorTorque = motorTorque;
            }
        }

        // Check if trigger was released this frame
        if (trigger.action.WasReleasedThisFrame())
        {
            //isPressed = false;
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = brakeTorque;
               
            }
        }

        
        // Assuming front 2 wheels steer (index 0 and 1)
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].steerAngle = (knob.value - 0.5f) * 120f;
        }
    }*/


    public InputActionReference trigger; // Input for forward/backward movement
    public XRKnob knob;                  // Used for steering (left/right)
    public float moveSpeed = 5f;         // Forward movement speed
    public float rotationSpeed = 50f;    // Rotation speed

    private Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Trigger press = move forward
        if (trigger.action.WasPressedThisFrame())
        {
            isMoving = true;
        }

        // Trigger release = stop moving
        if (trigger.action.WasReleasedThisFrame())
        {
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move forward in local Z direction
            rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            // Steer the forklift based on knob (value: 0 to 1)
            float steerInput = (knob.value - 0.5f) * 2f; // Normalized to -1 to 1
            float rotation = steerInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * turnOffset);
        }

       
    }
}

