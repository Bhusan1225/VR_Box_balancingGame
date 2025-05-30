using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;
using Unity.IO.LowLevel.Unsafe;

public class ForkliftController : MonoBehaviour
{

    [SerializeField] ForkliftEngineController engineController;

    public InputActionReference rightTrigger; // Forward (right hand)
    public InputActionReference leftTrigger;  // Backward (left hand)
    [SerializeField] XRKnob steering;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 50f;

    [Header("Lever")]
    [SerializeField] XRLever gearLever;
    [SerializeField] XRLever parkingBreakLever;

    private Rigidbody rb;
    private bool moveForward = false;
    private bool moveBackward = false;

    public  bool isReverseGearOn;
    
    [Header("Task")]
    [SerializeField] TaskManager taskManager;
    [SerializeField] ForkliftTask attemptedTask2;
    [SerializeField] ForkliftTask attemptedTask3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parkingBreakLever.value = false;


    }

     void Update()
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            
            if (parkingBreakLever.value == true)
            {
                taskManager.TryCompleteTask(attemptedTask2);//task 2
                HandleGearStatus();
                if (!isReverseGearOn)
                {
                    // Right trigger = forward
                    if (rightTrigger.action.WasPressedThisFrame())
                        moveForward = true;
                    if (rightTrigger.action.WasReleasedThisFrame())
                        moveForward = false;

                    // Left trigger = forward
                    if (leftTrigger.action.WasPressedThisFrame())
                        moveForward = true;
                    if (leftTrigger.action.WasReleasedThisFrame())
                        moveForward = false;

                }
                else if (isReverseGearOn)
                {
                    // Right trigger = backword
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
            

        }
    }

    public void HandleGearStatus()
    {

            if (gearLever.value == false)
            {
                isReverseGearOn = false;
                taskManager.TryCompleteTask(attemptedTask3); // task 3
            }
            else if (gearLever.value == true)
            {
                isReverseGearOn = true;
            }

    }

    void FixedUpdate()
    { 
        Vector3 moveDirection = Vector3.zero;

            if (!isReverseGearOn && moveForward == true)
                moveDirection = transform.forward;
            else if (isReverseGearOn && moveBackward == true)
                moveDirection = -transform.forward;
        

        //Movement
        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

            // Steering
            float steerInput = (steering.value - 0.5f) * 2f; // -1 to 1
            float rotation = steerInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * turnOffset);
        }
    }
}

