using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //check if time is running
        if (timeIsRunning)
        {
            if (timeRemaining >= 0) 
            { 
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }
    void DisplayTime (float timetodisplay) 
    {
        timetodisplay += 1;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.Floor(timeRemaining % 60);
        timeText.text = string.Format("{0:00} : {1:00}",minutes,seconds);  

    }
}
