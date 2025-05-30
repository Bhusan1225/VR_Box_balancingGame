using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrivingTestManager : MonoBehaviour
{

    [SerializeField]Stopwatch stopwatch;
    [SerializeField]TaskManager taskManager;

    [Header("Task")]
    [SerializeField] ForkliftTask attemptedTask4;
    [SerializeField] ForkliftTask attemptedTask5;
    [SerializeField] ForkliftTask attemptedTask6;
    private bool task4Completed = false;
    private bool task5Completed = false;
    private bool task6Completed = false;



    [Header("Achivement UI")]
    [SerializeField] TextMeshProUGUI achivementTimingText;
    [SerializeField] TextMeshProUGUI taskScoreText;
    [SerializeField] GameObject achivementUIPopup;
    [SerializeField] Image trofyImageHolder;
    [SerializeField] Image goldTrofyImageUI;
    [SerializeField] Image silverTrofyImageUI;
    [SerializeField] Image bronzeTrofyImageUI;
    [SerializeField] Image certificateImageUI;
    private void Start()
    {
        achivementUIPopup.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        int layerIndex = other.gameObject.layer;
        if (layerIndex == 8) //means start point
        {
            if(!task4Completed)
            {
                taskManager.TryCompleteTask(attemptedTask4);
                task4Completed = true;
            }
           
            stopwatch.StartStopwatch();
        }
        else if (layerIndex == 11) 
        {
            if (!task5Completed)
            {
                taskManager.TryCompleteTask(attemptedTask5);
                task5Completed = true;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        int layerIndex = other.gameObject.layer;
        if (layerIndex == 9) //means start point
        {
            stopwatch.StopStopwatch();
            if (!task6Completed)
            {
                taskManager.TryCompleteTask(attemptedTask6);
                task6Completed = true;
            }

            achivementUIPopup.SetActive(true);
            achivementTimingText.text = stopwatch.FormatTime(stopwatch.GetElapsedTime());
            taskScoreText.text = taskManager.GetTaskScore().ToString();

            //check time, check task points, check the forklift Condition
            if (stopwatch.GetElapsedTime() <= 70f && taskManager.CheckWinningScore() <= 10)
            {
                trofyImageHolder.sprite = goldTrofyImageUI.sprite;
                Debug.Log("Congrats you got gold");
            }
            else if (stopwatch.GetElapsedTime() >= 70f && stopwatch.GetElapsedTime() <= 120f &&
                    taskManager.CheckWinningScore() >= 10 && taskManager.CheckWinningScore() <= 20)
            {
                trofyImageHolder.sprite = silverTrofyImageUI.sprite;
                Debug.Log("Congrats you got Silver");
            }
            else if (stopwatch.GetElapsedTime() >= 120f && stopwatch.GetElapsedTime() <= 240f &&
                     taskManager.CheckWinningScore() >= 20 && taskManager.CheckWinningScore() <= 30)
            {
                trofyImageHolder.sprite = bronzeTrofyImageUI.sprite;
                Debug.Log("Congrats you got Bronze");
            }
            else
            {
                trofyImageHolder.sprite = certificateImageUI.sprite;
                Debug.Log("Better luck next time");
            }
        }
    }
}
