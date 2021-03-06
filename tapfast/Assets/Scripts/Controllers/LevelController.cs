using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private float timerValue;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Text hitCountText;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private GameObject mainMenuButton;

    [SerializeField]
    private GameObject backButton;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        // Create a timer and assign the custom Timer Finished Event
        if(GlobalData.GameMode == (int)GlobalData.GameModes.Classic)
        {
            GameObject timerObject = new GameObject();
            timer = timerObject.AddComponent<Timer>();
            timer.TimerFinished += timer_TimerFinished;
            timer.TimerEnabled = true;
            timer.CountDownFrom = timerValue;
            timerText.text = timer.TimeValue;
        }
        else if (GlobalData.GameMode == (int)GlobalData.GameModes.Infinite)
        {
            GameObject timerObject = new GameObject();
            timer = timerObject.AddComponent<Timer>();
            timer.TimerFinished += timer_TimerFinished;
            timer.TimerEnabled = true;
            timer.CountDownFrom = 0f;
            timer.CountUp = true;
            timerText.text = "00:00";
        }

        //Hide Items
        HideItems();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalData.GameMode == (int)GlobalData.GameModes.Classic && timer.TimerEnabled)
        {
            //Show remaining time
            timerText.text = timer.TimeValue;

            // Check active circles
            CheckActiveCircles();
        }
        else if (GlobalData.GameMode == (int)GlobalData.GameModes.Infinite)
        {
            //Show remaining time
            timerText.text = timer.TimeValue;

            // Check active and inactive circles
            CheckActiveCircles();
            CheckHitCircles(true);
        }
    }

    void timer_TimerFinished(object sender, EventArgs e)
    {
        //Remove none hit circles
        Circle[] activeCircles = FindObjectsOfType<Circle>(false);
        foreach (var circle in activeCircles)
        {
            Destroy(circle.gameObject);
        }

        //Check all hit circles
        hitCountText.enabled = true;
        CheckHitCircles(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    void HideItems()
    {
        //Hide these items until end
        if(GlobalData.GameMode == (int)GlobalData.GameModes.Classic)
        {
            hitCountText.enabled = false;
        }

        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    void CheckActiveCircles()
    {
        //Check all circles
        Circle[] circles = FindObjectsOfType<Circle>(false);

        //If there are no inactive circles, create one
        if (circles.Length == 0)
        {
            GameObject circle = (GameObject)Instantiate(Resources.Load("CircleWhite"));
        }
    }

    void CheckHitCircles(bool ShowHitCount)
    {
        // Get circles
        Circle[] circles = FindObjectsOfType<Circle>(true).Where(c => c.gameObject.activeSelf == false).ToArray();

        if(ShowHitCount)
        {
            hitCountText.text = "Hit Count: " + circles.Length.ToString();
        }
    }
}