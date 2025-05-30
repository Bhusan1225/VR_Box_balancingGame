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
    public int taskScore;
    public int taskTotalScore;

    void Start()
    {
        taskTotalScore = taskList.Count * 10;
        taskScore = taskTotalScore;
        ShowCurrentTask();
    }

    public int GetTaskScore()
    {
        return taskScore;
    }
    public int GetTaskTotalScore()
    {
        return taskTotalScore;
    }

    public int CheckWinningScore()
    {
        return  taskTotalScore - taskScore;
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
            taskScore -= 10;
        }
    }

    void ShowCurrentTask()
    {
        if (currentIndex < taskList.Count)
        {
            taskText.text = "Current Task: " + taskList[currentIndex].taskName;
            instructionText.text = "Hint: " + taskList[currentIndex].taskInstruction;
        }
        else
        {
            taskText.text = "All tasks completed!";
        }
    }
}
