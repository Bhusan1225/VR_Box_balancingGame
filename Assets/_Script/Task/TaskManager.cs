using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections.Generic;

public class TaskManager : MonoBehaviour
{
    public List<ForkliftTask> taskList; // drag ScriptableObjects here
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI instructionText;
    public int currentIndex = 0;
    public int score = 50;

    void Start()
    {
        ShowCurrentTask();
    }

    public void TryCompleteTask(ForkliftTask attemptedTask)
    {
        if (currentIndex < taskList.Count && attemptedTask == taskList[currentIndex])
        {
            
            Debug.Log("Correct task completed: " + attemptedTask.taskName);
            currentIndex++;
            ShowCurrentTask();
        }
        else
        {
           
            Debug.LogWarning("Wrong task order! Penalty applied.");
            score -= 10;
        }
    }

    void ShowCurrentTask()
    {
        if (currentIndex < taskList.Count)
        {
            taskText.text = "Current Task: " + taskList[currentIndex].taskName;
        }
        else
        {
            taskText.text = "✅ All tasks completed!";
        }
    }
}
