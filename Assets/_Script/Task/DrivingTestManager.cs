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
    [SerializeField] ForkliftTask attemptedTask8;
    [SerializeField] ForkliftTask attemptedTask9;
    private bool task4Completed = false;
    private bool task5Completed = false;
    private bool task6Completed = false;
    private bool task8Completed = false;
    private bool task9Completed = false;



    [Header("Achivement UI")]
    [SerializeField] TextMeshProUGUI achivementTimingText;
    [SerializeField] TextMeshProUGUI taskScoreText;
    [SerializeField] GameObject achivementUIPopup;
    [SerializeField] Image trofyImageHolder;

    [SerializeField] Image goldTrofyImage;
    [SerializeField] Image silverTrofyImage;
    [SerializeField] Image bronzeTrofyImage;
    [SerializeField] Image certificateImage;

    [Header("Task Type")]
    [SerializeField] TestTypeEnum testType;
    private void Start()
    {
        achivementUIPopup.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        int layerIndex = other.gameObject.layer;
        if (layerIndex == 8) //means start point
        {
            if (!task4Completed)
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
        else if (layerIndex == 12)
        {
            if (!task8Completed)
            {
                taskManager.TryCompleteTask(attemptedTask8);
                task8Completed = true;
            }
            stopwatch.ResetStopwatch();
            stopwatch.StartStopwatch();

        }
        else if (layerIndex == 13)
        {
            if (!task9Completed)
            {
                taskManager.TryCompleteTask(attemptedTask9);
                task9Completed = true;
                
            }
            stopwatch.StopStopwatch();
            AchivementPopup();
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

            
            AchivementPopup();
            
            

        }
    }


    void AchivementPopup()
    {
        //SoundController.Instance.PlaySFX(SoundEffectEnum.Win);
        achivementUIPopup.SetActive(true);
        achivementTimingText.text = "Time:" + stopwatch.FormatTime(stopwatch.GetElapsedTime());
        taskScoreText.text = "Score: " + taskManager.GetTaskScore().ToString();

        float elapsedTime = stopwatch.GetElapsedTime();
        int score = taskManager.CheckWinningScore();

        // GOLD: Time <= 70s AND Score <= 10
        if (elapsedTime <= 70f && score <= 10)
        {
            trofyImageHolder.sprite = goldTrofyImage.sprite;
            Debug.Log("Congrats! You got Gold.");
        }
        // SILVER: Time between 70-120s AND Score <= 20
        else if (elapsedTime > 70f && elapsedTime <= 120f && score <= 20)
        {
            trofyImageHolder.sprite = silverTrofyImage.sprite;
            Debug.Log("Congrats! You got Silver.");
        }
        // BRONZE: Time between 120-240s AND Score <= 30
        else if (elapsedTime > 120f && elapsedTime <= 240f && score <= 30)
        {
            trofyImageHolder.sprite = bronzeTrofyImage.sprite;
            Debug.Log("Congrats! You got Bronze.");
        }
        // CERTIFICATE: Anything worse
        else
        {
            trofyImageHolder.sprite = certificateImage.sprite;
            Debug.Log("Better luck next time!");
        }
    }
}
