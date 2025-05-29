using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    [SerializeField] Transform lift;
    //[SerializeField] Transform originallift;
    [SerializeField] float moveIncrement = 0.1f;

    [Header("Vertical Limits (Y Axis)")]
    //[SerializeField] float minY;
    [SerializeField] float maxY;

    [Header("Horizontal Limits (Z Axis)")]
    //[SerializeField] float minZ;
    [SerializeField] float maxZ;

    Vector3 orgPosition;

    bool front;
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
            front = true;
        }
    }

    public void LiftBackWhilePressed(float value)
    {
        if (value > 0.8f && front == true)
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
        Vector3 direction = lift.parent.up;
        Vector3 newPosition = lift.position + direction * moveIncrement;

        if (newPosition.y <= orgPosition.y + maxY)
        {
            lift.position = newPosition;
        }
    }

    public void LiftDown() //done
    {
        Vector3 direction = -lift.parent.up;
        Vector3 newPosition = lift.position + direction * moveIncrement;

        if (newPosition.y >= orgPosition.y)
        {
            lift.position = newPosition;
        }
    }

    public void LiftFront() // done
    {
        Vector3 direction = lift.parent.forward;
        Vector3 newPosition = lift.position + direction * moveIncrement;

        if (newPosition.z <= orgPosition.z +maxZ)
        {
            lift.position = newPosition;
        }
    }

    public void LiftBack() //done
    {
        Vector3 direction = -lift.parent.forward;
        Vector3 newPosition = lift.position + direction * moveIncrement;

        if (newPosition.z >= orgPosition.z )
        {
            lift.position = newPosition;
        }
    }

    // Optional left/right movement if needed

    public void MoveLeft()
    {
        Vector3 direction = -lift.parent.right;
        lift.position += direction * moveIncrement;
    }

    public void MoveRight()
    {
        Vector3 direction = lift.parent.right;
        lift.position += direction * moveIncrement;
    }

}
