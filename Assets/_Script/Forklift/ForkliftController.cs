using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;
using Unity.IO.LowLevel.Unsafe;

public class ForkliftController : MonoBehaviour
{
    [Header("Engine & Input")]
    public InputActionReference rightTrigger; // Right hand trigger
    public InputActionReference leftTrigger;  // Left hand trigger
    private bool isForkliftEngine;
    
    [Header("Movement Settings")]
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 4f;
    private float currentSpeed = 0f;
    private float inputValue = 0f;

    [Header("Steering")]
    [SerializeField] XRKnob steering;
    [SerializeField] float rotationSpeed = 50f;

    [Header("Lever")]
    [SerializeField] XRLever gearLever;
    [SerializeField] XRLever parkingBreakLever;
    private bool isReverseGearOn = false;
    
    [Header("Task")]
    [SerializeField] TaskManager taskManager;
    [SerializeField] ForkliftTask attemptedTask1; 
    [SerializeField] ForkliftTask attemptedTask2;
    [SerializeField] ForkliftTask attemptedTask3;
    private bool task2Completed = false;
    private bool task3Completed = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parkingBreakLever.value = false;

    }

     void Update()
    {
        if (!isForkliftEngine || !parkingBreakLever.value)
        {
            inputValue = 0f;
            return;
        }

        if (parkingBreakLever.value == true)
            {
                if (!task2Completed)
                {
                    taskManager.TryCompleteTask(attemptedTask2); // task 2
                    task2Completed = true; 
                }
                HandleGearStatus();

            // Read trigger pressure from 0 to 1
            float rightInput = rightTrigger.action.ReadValue<float>();
            float leftInput = leftTrigger.action.ReadValue<float>();
            
            inputValue = Mathf.Max(rightInput, leftInput); // Choose higher pressure

            // Task 2: Parking brake applied
            if (parkingBreakLever.value && !task2Completed)
            {
                taskManager.TryCompleteTask(attemptedTask2);
                task2Completed = true;
            }

            // Task 3: Start moving
            if (inputValue > 0.1f && !isReverseGearOn && !task3Completed)
            {
                taskManager.TryCompleteTask(attemptedTask3);
                task3Completed = true;
            }

        }
    }

    public bool GetForkliftEnginePower()
    {
        return isForkliftEngine;
    }

    public void SetForkliftEnginePower(bool powerOn)
    {
        isForkliftEngine = powerOn;
        taskManager.TryCompleteTask(attemptedTask1);

    }
    void HandleGearStatus()
    {
        isReverseGearOn = gearLever.value;
    }

    void FixedUpdate()
    {
        float targetSpeed = inputValue * maxSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.fixedDeltaTime * (inputValue > 0 ? acceleration : deceleration));
        Vector3 direction = isReverseGearOn ? -transform.forward : transform.forward; // Checks the gear and set the direction of forklift
        Vector3 movement = direction * currentSpeed * Time.fixedDeltaTime;

        bool isMoving = movement != Vector3.zero;
        if (movement != Vector3.zero)
        {
            rb.MovePosition(rb.position + movement); // Set the movement of the forklift 

            // Steering
            float steerInput = (steering.value - 0.5f) * 2f; // -1 to 1
            float rotation = steerInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0f, rotation, 0f);
            rb.MoveRotation(rb.rotation * turnOffset); // Set the rotation of the forkliftas per the steering Input 
        }

       
    }
}

