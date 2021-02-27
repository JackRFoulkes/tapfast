using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Properties
    public bool TimerEnabled { get; set; }
    public float CountDownFrom { get; set; }
    public string TimeValue { get { return DisplayTime(CountDownFrom); } }
    #endregion

    #region Events
    public event EventHandler TimerFinished;
    #endregion

    void Update()
    {
        if (TimerEnabled)
        {
            if (CountDownFrom > 0)
            {
                CountDownFrom -= Time.deltaTime;
                //Debug.Log(DisplayTime(CountDownFrom));
            }
            else
            {
                //Debug.Log(DisplayTime(CountDownFrom));
                TimerEnabled = false;
                CountDownFrom = 0;
                OnTimerFinished(EventArgs.Empty);
            }
        }
    }
    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    protected virtual void OnTimerFinished(EventArgs e)
    {
        EventHandler handler = TimerFinished;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}