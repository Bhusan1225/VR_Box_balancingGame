using UnityEngine;
using System.Collections.Generic;

public class ForkliftPathLine : MonoBehaviour
{
    public Transform forklift;
    public List<Transform> waypoints; // Add waypoints in the inspector
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 5f;
        lineRenderer.endWidth = 5f;
    }

    void Update()
    {
        if (waypoints.Count > 0)
        {
            lineRenderer.positionCount = waypoints.Count + 1;
            lineRenderer.SetPosition(0, forklift.position);

            for (int i = 0; i < waypoints.Count; i++)
            {
                lineRenderer.SetPosition(i + 1, waypoints[i].position);
            }
        }
    }
}
