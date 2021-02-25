using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool TimerEnabled { get; set; }
    public float CountDownFrom { get; set; }

    void Update()
    {
        if (TimerEnabled)
        {
            if (CountDownFrom > 0)
            {
                CountDownFrom -= Time.deltaTime;
                Debug.Log(DisplayTime(CountDownFrom));
            }
            else
            {
                Debug.Log(DisplayTime(CountDownFrom));
                CountDownFrom = 0;
                TimerEnabled = false;
            }
        }
    }
    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}