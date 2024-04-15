using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DeathSceneManger : MonoBehaviour
{
    public float MinTime;
    public float MinTimeExitSign;
    public float MaxTime;
    public float MaxTimeExitSign;
    public float Timer;
    float exitSignTimer;
    public Light spotLight;
    public Light exitSignLight;

    public List<GameObject> manequinnsToShow;

    public TextAnimation textAnimation;

    // Tooltip
    [SerializeField] 
    private GameObject TooltipForNote;

    [SerializeField] 
    private GameObject TooltipForDoor;

    // Start is called before the first frame update
    void Start()
    {
        GlobalState.SetStartLevel(true);
        GlobalState.SetGameOver(false);
        Timer = Random.Range(MinTime, MaxTime);
        exitSignTimer = Random.Range(MinTimeExitSign, MaxTimeExitSign);
        int numDeaths = PlayerPrefs.GetInt("Deaths", 1);
        for (int i = 0; i < manequinnsToShow.Count; i++) {
            manequinnsToShow[i].SetActive(i < numDeaths);
        }
        SetTextToDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        LightFlickering();
    }

    public void DebugTesting()
    {
        Debug.Log("Button click works");
    }

    void LightFlickering() {
        if (Timer > 0) {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0) {
            spotLight.enabled = !spotLight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }

        if (exitSignTimer > 0) {
            exitSignTimer -= Time.deltaTime;
        }
        if (exitSignTimer <= 0) {
            exitSignLight.enabled = !exitSignLight.enabled;
            exitSignTimer = Random.Range(MinTimeExitSign, MaxTimeExitSign);
        }
    }

    void SetTextToDisplay() {
        string textOnPaper = "";
        switch (GlobalState.GetLevel()) {
            case 1:
                // textOnPaper = "Uh-oh! Flames from an electrical overload! Water won't help you here. Find something to smother the flames, fast! \nBut remember, with each misstep, the shadows grow longer...";
                textOnPaper = GlobalState.GetLevel().ToString();
                break;

            case 2:
                // textOnPaper = "Ding Dong! Someone suspicious at the door? Better lock it and call the police!";
                textOnPaper = GlobalState.GetLevel().ToString();
                break;

            case 3:
                // textOnPaper = "Watch out! The oil's ignited in the kitchen! Water will only make it worse! Cut off the heat and add cool oil before it's too late...";
                textOnPaper = GlobalState.GetLevel().ToString();
                break;

            case 4:
                // textOnPaper = "Careful, oven fires are tricky. You can't just throw water on them. You need to smother the flames with the right extinguisher!";
                textOnPaper = GlobalState.GetLevel().ToString();
                break;

            case 5:
                // textOnPaper = "Uh-oh! Flames from an electrical overload! Water won't help you here. Find something to smother the flames, fast! \nBut remember, with each misstep, the shadows grow longer...";
                textOnPaper = GlobalState.GetLevel().ToString();
                break;
            case 6:
                // textOnPaper = "Oh no! The ceiling's coming down! You need to find a strong cover, fast!";
                textOnPaper = GlobalState.GetLevel().ToString();
                break;
            default:
                textOnPaper = GlobalState.GetLevel().ToString();
                break;
        }
        textAnimation.textToDisplay.text = textOnPaper;

    }

    public void hoverOnNoteForToolTip()
    {
        TooltipForNote.SetActive(true);
    }

    public void hoverOffNoteForToolTip()
    {
        TooltipForNote.SetActive(false);
    }

    public void hoverOnDoorForToolTip()
    {
        TooltipForDoor.SetActive(true);
    }

    public void hoverOffDoorForToolTip()
    {
        TooltipForDoor.SetActive(false);
    }

}
