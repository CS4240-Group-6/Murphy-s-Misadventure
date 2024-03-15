using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        string playerDiedAt = PlayerPrefs.GetString("LocationOfDeath", "bedroomFire");
        SetTextToDisplay(playerDiedAt);
    }

    // Update is called once per frame
    void Update()
    {
        LightFlickering();
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

    void SetTextToDisplay(string sceneWherePlayerDiedAt) {
        string textOnPaper = "";
        switch (sceneWherePlayerDiedAt) {
            case "bedroomFire":
                textOnPaper = "Uh-oh! Flames from an electrical overload! Water won't help you here. Find something to smother the flames, fast! \nBut remember, with each misstep, the shadows grow longer...";
                break;

            case "bedroomEarthquake":
                textOnPaper = "Rumble rumble! Brace yourself, it's the earth shaking! Quick, find cover and hold on tight!";
                break;

            case "kitchenFire":
                textOnPaper = "Watch out! The oil's ignited in the kitchen! Water will only make it worse! Cover those flames and cut off the heat before it's too late...";
                break;

            case "kitchenGasLeak":
                textOnPaper = "Careful now, that's not just a gas stove leak, it's a ticking time bomb. Move fast!";
                break;
        }
        textAnimation.textToDisplay.text = textOnPaper;

    }

}
