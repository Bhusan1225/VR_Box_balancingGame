using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    [SerializeField] Transform lift;
    [SerializeField] ForkliftEngineController engineController;
    [SerializeField] float moveIncrement = 0.1f;

    [Header("Horizontal Limits (X Axis)")]
    [SerializeField] float maxRightX;
    [SerializeField] float maxLeftX;

    [Header("Vertical Limits (Y Axis)")]
    [SerializeField] float maxY;

    [Header("Horizontal Limits (Z Axis)")]
    [SerializeField] float maxZ;

   

    Vector3 orgPosition;

 
    // Called by input when holding movement

    private void Start()
    {
        orgPosition = lift.position;
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

    public void LiftFrontWhilePressed(float value)
    {
        if (value > 0.8f)
        {
            LiftFront();
            
        }
    }

    public void LiftBackWhilePressed(float value)
    {
        if (value > 0.8f )
        {
            LiftBack();
        }
    }

    // Optional: Left/Right (uncomment if needed)
    public void LiftLeftWhilePressed(float value)
    {
        if (value > 0.8f) MoveLeft();
    }

    public void LiftRightWhilePressed(float value)
    {
        if (value > 0.8f) MoveRight();
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

    public void LiftFront() // done
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            Vector3 direction = lift.parent.forward;
            Vector3 newPosition = lift.position + direction * moveIncrement;

            if (newPosition.z <= orgPosition.z + maxZ)
            {
                lift.position = newPosition;
            }
        }
    }

    public void LiftBack() //done
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            Vector3 direction = -lift.parent.forward;
            Vector3 newPosition = lift.position + direction * moveIncrement;

            if (newPosition.z >= orgPosition.z)
            {
                lift.position = newPosition;
            }
        }
    }

    // Optional left/right movement if needed

    public void MoveLeft()
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            Vector3 direction = -lift.parent.right;
            Vector3 newPosition = lift.position + direction * moveIncrement;
            if (newPosition.x <= orgPosition.x + maxLeftX)
            {
                lift.position = newPosition;
            }
        }
    }

    //public void MoveToOrigin()
    //{
    //    Vector3 direction = lift.parent.right;
    //    Vector3 newPosition = lift.position + direction * moveIncrement;
    //    if (newPosition.x <= orgPosition.x)
    //    {
    //        lift.position = newPosition;
    //    }
    //}

    public void MoveRight()
    {
        if (engineController.GetForkliftEnginePower() == true)
        {
            Vector3 direction = lift.parent.right;
            Vector3 newPosition = lift.position + direction * moveIncrement;

            if (newPosition.x <= orgPosition.x + maxRightX)
            {
                lift.position = newPosition;
            }
        }
    }

}
