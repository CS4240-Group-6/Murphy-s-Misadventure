using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTextManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI levelText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI levelClearText;
    private int previousLevel = 0;
    private float timeRemaining = 180; // 3 minute timer
    // private float timeRemaining = 10; // 10 second timer

    private bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        levelClearText.gameObject.SetActive(false);
        timerIsRunning = true;
        UpdateLevelText();
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
                GlobalState.SetGameOver(true);
            }
        }

        if (GlobalState.GetLevel() != previousLevel) {
            UpdateLevelText();
        }
    }

    public void SetTimerRunning(bool running) {
        timerIsRunning = running;
    }

    private void UpdateLevelText() {
        levelText.text = "Level " + GlobalState.GetLevel().ToString();
        previousLevel = GlobalState.GetLevel();
    }

    private void DisplayTime(float timeToDisplay)
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

    public void DisplayLevelComplete() {
        levelClearText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(false);
        levelText.gameObject.SetActive(false);
        
        timerIsRunning = false;
    }
}
