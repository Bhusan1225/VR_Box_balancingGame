using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingTestManager : MonoBehaviour
{

    [SerializeField]Stopwatch stopwatch;
    [SerializeField]TaskManager taskManager;
    [SerializeField] ForkliftTask attemptedTask4;
    private void OnTriggerEnter(Collider other)
    {
        int layerIndex = other.gameObject.layer;
        if (layerIndex == 8) //means start point
        {
            taskManager.TryCompleteTask(attemptedTask4);
            stopwatch.StartStopwatch();
        }
        else if (layerIndex == 10) 
        { 
            // damage 
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        int layerIndex = other.gameObject.layer;
        if (layerIndex == 9) //means start point
        {
            stopwatch.StopStopwatch();
        }
    }
}
