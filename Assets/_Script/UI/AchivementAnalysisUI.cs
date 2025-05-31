using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AchivementAnalysisUI : MonoBehaviour
{

    [SerializeField] Stopwatch stopwatch; // for the timing
    [SerializeField] TaskManager taskManager; // for checking the no. of tasks completed by the 

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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("ParkingZone") )
        {
            achivementUIPopup.SetActive(true);
            achivementTimingText.text = stopwatch.FormatTime(stopwatch.GetElapsedTime());
            taskScoreText.text = taskManager.GetTaskScore().ToString();

            //check time, check task points, check the forklift Condition
            if (stopwatch.GetElapsedTime() <= 70f  &&  taskManager.CheckWinningScore() == 10)    
            {
                //means around 1 min 
                trofyImageHolder = goldTrofyImageUI;

            }
            else if(stopwatch.GetElapsedTime() >= 70f && stopwatch.GetElapsedTime() <= 120f && 
                    taskManager.CheckWinningScore() == 20)
            {
                //means around 2 min
                trofyImageHolder = silverTrofyImageUI;
            }
            else if (stopwatch.GetElapsedTime() >= 120f && stopwatch.GetElapsedTime() <= 240f && 
                     taskManager.CheckWinningScore() == 30)
            {
                //means around 3 min
                trofyImageHolder = bronzeTrofyImageUI;
            }
            else
            {   //means more than 3 min
                trofyImageHolder = certificateImageUI;
            }
          
        }
    }

   
}
