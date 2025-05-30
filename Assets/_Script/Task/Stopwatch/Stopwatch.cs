using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText; // Assign a UI Text element
    private float elapsedTime = 0f;
    private bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            stopwatchText.text = FormatTime(elapsedTime);
        }
    }

    public void StartStopwatch()
    {
        isRunning = true;
    }

    public void StopStopwatch()
    {
        isRunning = false;
    }

    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0f;
        stopwatchText.text = "00:00:00";
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
