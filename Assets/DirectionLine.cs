using UnityEngine;

public class DirectionLine : MonoBehaviour
{
    public Transform forklift;
    public Transform destination;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Line with 2 points
    }

    void Update()
    {
        if (forklift != null && destination != null)
        {
            lineRenderer.SetPosition(0, forklift.position);
            lineRenderer.SetPosition(1, destination.position);
        }
    }
}
