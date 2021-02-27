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

    Timer timer;

    // Awake is called before start
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        // Create a timer and assign the custom Timer Finished Event
        GameObject timerObject = new GameObject();
        timer = timerObject.AddComponent<Timer>();
        timer.TimerFinished += timer_TimerFinished; 
        timer.TimerEnabled = true;
        timer.CountDownFrom = timerValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.TimerEnabled)
        {
            //Check all circles
            Circle[] circles = FindObjectsOfType<Circle>(false);

            //If there are no inactive circles, create one
            if(circles.Length == 0)
            {
                GameObject circle = (GameObject)Instantiate(Resources.Load("CircleWhite"));
            }
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
        Circle[] circles = FindObjectsOfType<Circle>(true).Where(c => c.gameObject.activeSelf == false).ToArray();

        //Show hit count
        GameObject.Find("HitCount").GetComponent<Text>().text = "Hit Count: " + circles.Length.ToString();
    }
}