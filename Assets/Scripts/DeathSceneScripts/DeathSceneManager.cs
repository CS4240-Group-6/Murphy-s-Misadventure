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

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
        exitSignTimer = Random.Range(MinTimeExitSign, MaxTimeExitSign);
        int numDeaths = PlayerPrefs.GetInt("Deaths", 1);
        for (int i = 0; i < manequinnsToShow.Count; i++) {
            manequinnsToShow[i].SetActive(i < numDeaths);
        }
        string playerDiedAt = GetPlayerDeathLocation();
        SetTextToDisplay(playerDiedAt);
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

    private string GetPlayerDeathLocation() {
        switch(GlobalState.GetLevel()) {
            case 1:
                return PlayerPrefs.GetString("LocationOfDeath", "livingRoomFlowerPot");
            case 2:
                return  PlayerPrefs.GetString("LocationOfDeath", "livingRoomFire");
            case 3:
                return PlayerPrefs.GetString("LocationOfDeath", "kitchenGasLeak");
            case 4:
                return PlayerPrefs.GetString("LocationOfDeath", "kitchenOilFire");
            case 5:
                return PlayerPrefs.GetString("LocationOfDeath", "kitchenOvenFire");
            case 6:
                return PlayerPrefs.GetString("LocationOfDeath", "bedroomFire");
            case 7:
                return PlayerPrefs.GetString("LocationOfDeath", "bedroomEarthquake");
            case 8:
                return PlayerPrefs.GetString("LocationOfDeath", "livingRoomBreakIn");
            default:
                return PlayerPrefs.GetString("LocationOfDeath", "Unknown Location of Death");
        }
    }

    void SetTextToDisplay(string sceneWherePlayerDiedAt) {
        string textOnPaper = "";
        switch (sceneWherePlayerDiedAt) {
            case "bedroomFire":
                textOnPaper = "Uh-oh! Flames from an electrical overload! Water won't help you here. Find something to smother the flames, fast! \nBut remember, with each misstep, the shadows grow longer...";
                break;

            case "bedroomEarthquake":
                textOnPaper = "Rumble rumble! Brace yourself, it's the earth shaking! Quick, find cover and hold on tight!";
                break;

            case "kitchenOilFire":
                textOnPaper = "Watch out! The oil's ignited in the kitchen! Water will only make it worse! Cut off the heat and add cool oil before it's too late...";
                break;

            case "kitchenGasLeak":
                textOnPaper = "Careful now, that's not just a gas stove leak, it's a ticking time bomb. Move fast!";
                break;

            case "kitchenOvenFire":
                textOnPaper = "Careful, oven fires are tricky. You can't just throw water on them. You need to smother the flames with the right extinguisher!";
                break;
        }
        textAnimation.textToDisplay.text = textOnPaper;

    }

}
