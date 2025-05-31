using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    [SerializeField] Transform lift;
    [SerializeField] Transform originalLift;

    [SerializeField] ForkliftEngineController engineController;
    [SerializeField] float moveIncrement = 0.1f;

    [Header("Horizontal Limits (X Axis)")]
    [SerializeField] float maxRightX;
    [SerializeField] float maxLeftX;

    [Header("Vertical Limits (Y Axis)")]
    [SerializeField] float maxY;

    [Header("Horizontal Limits (Z Axis)")]
    [SerializeField] float maxZ;

    [Header("Task")]
    [SerializeField] TaskManager taskManager;
    [SerializeField] ForkliftTask attemptedTask7;
    private bool task7Completed = false;

    public Vector3 orgPosition;
    


    private void Update()
    {
        orgPosition = originalLift.position;
        
    }
    public void LiftUpWhilePressed(float value)
    {
        if (value > 0.8f)
        {
            LiftUp();
        }
    }

    public void LiftDownWhilePressed(float value)
    {
        if (value > 0.8f)
        {
            LiftDown();
        }
    }



    public void LiftUp() // done
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            Vector3 direction = lift.parent.up;
            Vector3 newPosition = lift.position + direction * moveIncrement;

            if (newPosition.y <= orgPosition.y + maxY)
            {
                lift.position = newPosition;
                if (!task7Completed)
                {
                    taskManager.TryCompleteTask(attemptedTask7);
                    task7Completed = true;
                }
            }
        }
    }

    public void LiftDown() //done
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            Vector3 direction = -lift.parent.up;
            Vector3 newPosition = lift.position + direction * moveIncrement;

            if (newPosition.y >= orgPosition.y)
            {
                lift.position = newPosition;
            }
        }
    }


}
