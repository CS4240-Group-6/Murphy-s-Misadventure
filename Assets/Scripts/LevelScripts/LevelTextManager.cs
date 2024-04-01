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
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private GameObject nextLevelButton;
    public GameObject levelCanvas; // We can turn off or on the canvas at the start and end of a level
    private int previousLevel = 0;
    public static float timeRemaining = 180; // 3 minute timer

    private bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "";
        descriptionText.text = "";
        timerIsRunning = true;
        nextLevelButton.SetActive(false);

        StartCoroutine(LevelIntro());
        ShowCanvas();

        // UpdateLevelText();
        UpdateLevelTexts();
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
            UpdateLevelTexts();
        }
    }

    IEnumerator LevelIntro() 
    {
        ShowCanvas();
        yield return new WaitForSeconds(5f);
        HideCanvas();
    }

    public void ShowCanvas()
    {
        levelCanvas.gameObject.SetActive(true);
    }
    
    public void HideCanvas()
    {
        levelCanvas.gameObject.SetActive(false);
    }

    public void SetTimerRunning(bool running) {
        timerIsRunning = running;
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

    public void DisplayLevelTexts() 
    {
        if (GlobalState.IsGameOver()) {
            StartCoroutine(LevelIntro());
        } else {
            ShowCanvas();
            nextLevelButton.SetActive(true);
        }

        timeText.gameObject.SetActive(false);        
        timerIsRunning = false;
    }

    public void MoveToNextLevel()
    {
        Debug.Log("Button click works!");

        // If scene got another level, press button start new level
        // If the next level in another scene, then need lead them to the door
        int nextLevel = GlobalState.GetLevel() + 1;

        if (nextLevel == 3)
        {
            // Regarding the doors we can set check if current level is the 2nd level of the scene and only then you can enter the room/ load new scene
            levelText.text = "";
            descriptionText.text = "Please proceed to the Kitchen";
            Invoke("HideCanvas", 5f);
        } else if (nextLevel == 5)
        {
            // Regarding the doors we can set check if current level is the 2nd level of the scene and only then you can enter the room/ load new scene
            levelText.text = "";
            descriptionText.text = "Please proceed to the Bedroom";
            Invoke("HideCanvas", 5f);
        } else
        {
            // Call the other function in the scene for the next level

            HideCanvas();
        }
        
        GlobalState.IncrementLevel();

        switch(nextLevel) {
            case 2:
                break;
            case 4:
                // FindObjectOfType<KitchenEmergencies>().StartOvenFireScene();
                break;
            case 6:
                FindObjectOfType<BedroomEmergencies>().StartEarthquakeScene();
                break;
        }
    }

    // To update level information
    private void UpdateLevelTexts()
    {
        int level = GlobalState.GetLevel();
        bool isStart = GlobalState.IsStartLevel(); // Global boolean indicating if the level is at the intro stage or the end
        bool isSuccess = !GlobalState.IsGameOver(); // Global boolean indicating if the level was passed successfully or failed

        string levelName = "";
        string description = "";

        switch (level)
        {
            case 1:
                levelName = isStart ? "Living Room - Electrical Hazard" : isSuccess ? "Level Completed" : "Level Failed";
                description = isStart ? "Welcome to Level 1. Home sweet home... but what's this? You notice a cup tipped over, liquid spilling onto a plugged-in extension cord. Can you avert the sparking disaster waiting to happen?" 
                                    : isSuccess ? "Well done! You quickly cut off the power supply to the extension cord and pulled it out safely. You've prevented a potential electrical fire and protected your home." 
                                    : "Oops! Looks like you've been zapped. Remember, water and electricity are a dangerous mix. Head to the deathroom to learn more about electrical safety. Don't give up, you'll do better next time!";
                break;
            case 2:
                levelName = isStart ? "Living Room - Intruder Alert" : isSuccess ? "Level Completed" : "Level Failed";
                description = isStart ? "Welcome to Level 2. As the evening sets in, an unexpected visitor arrives. Knocking... Lock picking... Is someone trying to barge in? Secure the door and protect your home!" 
                                    : isSuccess ? "Excellent job! By locking the door and warning the stranger, you've kept yourself safe from a potential break-in. Always be cautious with unknown visitors." 
                                    : "That was close! The door was breached, and your safety compromised. Let's revisit the safety protocols in the deathroom. Remember, perseverance is key!";
                break;
            case 3:
                levelName = isStart ? "Kitchen - Fire Challenge" : isSuccess ? "Level Completed" : "Level Failed";
                description = isStart ? "Welcome to Level 3. You smell something burning in the kitchen. A small fire has started from the stove. It's time to put your fire safety knowledge to the test!" 
                                    : isSuccess ? "Fantastic! You turned off the stove and covered the pan to put out the fire. Your quick thinking has kept a small problem from becoming a big one." 
                                    : "It looks like the fire got out of control. Don't worry, mistakes happen. In the deathroom, we'll cover what you can do to tackle fires safely. Keep trying!";
                break;
            case 4:
                levelName = isStart ? "Kitchen - Oven Overheat" : isSuccess ? "Level Completed" : "Level Failed";
                description = isStart ? "Welcome to Level 4. Something's wrong... smoke is coming from the oven. An oven fire can turn dangerous quickly. Can you handle the heat?" 
                                    : isSuccess ? "Impressive work! You turned off the oven and used the fire extinguisher to douse the flames. Your actions prevented a serious fire." 
                                    : "The situation got heated, and the fire spread. In the deathroom, we'll go over how to safely deal with oven fires. Sharpen your skills, and come back stronger!";
                break;
            case 5:
                levelName = isStart ? "Bedroom- Electrical Fire" : isSuccess ? "Level Completed" : "Level Failed";
                description = isStart ? "Welcome to Level 5. Sparks from an overloaded adapter? This could lead to an electrical fire. Stay calm and think about your next steps carefully." 
                                    : isSuccess ? "You did it! By turning off the circuit breaker first, then using the right extinguisher, you've safely extinguished the electrical fire. A true problem-solver in action!" 
                                    : "The sparks turned into a blaze, but don't lose heart. The deathroom is the place to brush up on handling electrical fires. Return to the challenge when you're ready!";
                break;
            case 6:
                levelName = isStart ? "Bedroom - Earthquake Preparedness" : isSuccess ? "Level Completed" : "Level Failed";
                description = isStart ? "Welcome to Level 6. The ground shakes beneath you - an earthquake! Quick action is required to navigate this shaking ground. Find safety!" 
                                    : isSuccess ? "Bravo! You found a sturdy shelter and stayed safe during the quake. Remember, when the earth shakes, the risk it takes; your safety, your stakes." 
                                    : "The quake shook you up. Use this experience to learn in the deathroom about safe spots during an earthquake. Your courage is your strength!";
                break;
        }

        levelText.text = levelName;
        levelText.color = isStart ? Color.white : isSuccess ? Color.green : Color.red;
        descriptionText.text = description;
    }

}
