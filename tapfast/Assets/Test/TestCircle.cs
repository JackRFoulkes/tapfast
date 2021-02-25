using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCircle : MonoBehaviour
{

    // Awake is the first thing to be called
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject timerObject = new GameObject();
        Timer timer = timerObject.AddComponent<Timer>();

        timer.TimerEnabled = true;
        timer.CountDownFrom = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
