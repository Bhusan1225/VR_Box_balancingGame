using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftEngineController : MonoBehaviour
{
    [SerializeField] bool isForkliftEngine;
    [SerializeField] TaskManager taskManager;
    [SerializeField] ForkliftTask attemptedTask;

    // Start is called before the first frame update
    void Start()
    {
        isForkliftEngine = false;
    }

    public bool GetForkliftEnginePower()
    {
        return isForkliftEngine;
    }


    public void SetForkliftEnginePower(bool powerOn)
    {
        isForkliftEngine = powerOn;
        //if (isForkliftEngine)
        //{
        //    taskManager.TryCompleteTask(attemptedTask);
        //}
        taskManager.TryCompleteTask(attemptedTask);

    }
}
