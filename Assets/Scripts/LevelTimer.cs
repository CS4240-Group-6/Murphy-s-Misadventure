using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 180; // 3 minute timer
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:#0}:{1:00}", minutes, seconds);

        if (timeRemaining < 30) 
        {
            timeText.color = Color.red;
        }
        else if (timeRemaining < 60) 
        {
            timeText.color = Color.yellow;
        }
        else
        {
            timeText.color = Color.green;
        }
    }
}
