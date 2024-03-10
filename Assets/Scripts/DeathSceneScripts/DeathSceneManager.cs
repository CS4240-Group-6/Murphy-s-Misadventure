using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
        exitSignTimer = Random.Range(MinTimeExitSign, MaxTimeExitSign);
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
}
