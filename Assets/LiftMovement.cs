using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    [SerializeField] Transform lift;
    [SerializeField] float moveIncrement = 0.1f;

    [Header("Vertical Limits (Y Axis)")]
    [SerializeField] float minY = 0f;
    [SerializeField] float maxY = 5f;

    [Header("Horizontal Limits (X Axis)")]
    [SerializeField] float minX = -2f;
    [SerializeField] float maxX = 2f;

    public void LiftUp()
    {
        Vector3 liftPosition = lift.position;
        if (liftPosition.y + moveIncrement <= maxY)
        {
            liftPosition.y += moveIncrement;
            lift.position = liftPosition;
        }
    }

    public void LiftDown()
    {
        Vector3 liftPosition = lift.position;
        if (liftPosition.y - moveIncrement >= minY)
        {
            liftPosition.y -= moveIncrement;
            lift.position = liftPosition;
        }
    }

    public void MoveLeft()
    {
        Vector3 liftPosition = lift.position;
        if (liftPosition.x - moveIncrement >= minX)
        {
            liftPosition.x -= moveIncrement;
            lift.position = liftPosition;
        }
    }

    public void MoveRight()
    {
        Vector3 liftPosition = lift.position;
        if (liftPosition.x + moveIncrement <= maxX)
        {
            liftPosition.x += moveIncrement;
            lift.position = liftPosition;
        }
    }
}
