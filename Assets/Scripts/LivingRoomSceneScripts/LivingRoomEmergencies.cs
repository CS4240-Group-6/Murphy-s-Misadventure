using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomEmergencies : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;
    public float Timer;

    // Sound Script
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);

        StartLightFuseScene();
        // StartIntruderScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
        Scene starts
        5s later -> sparks in extension cord starts
        20s later -> power cut off and dim emergency light on
    */
    public void StartLightFuseScene()
    {
        Invoke("StartVoiceOver1", 5.0f);
        Invoke("StartVoiceOver2", );
        Invoke("StartVoiceOver3", );
    }


    void StartVoiceOver1()
    {
        soundManager.Play();
    }

    void StartVoiceOver2()
    {
        soundManager.PlayShouldTurnOffSomethingAndCoverPan();
    }

    void StartVoiceOver3()
    {
        soundManager.PlayShouldTurnOffSomethingAndCoverPan();
    }

    /**
        Scene starts
        10s later -> pan catches on fire
        50s later -> pan fire strenghtens
        1min later -> fire spreads to whole stove if unattended
        10s later -> stove fire strengthens
    */
    public void StartIntruderScene()
    {

    }

    void StartVoiceOver4()
    {
        soundManager.PlaySmellSomethingBurning();
    }

    void StartVoiceOver5()
    {
        soundManager.PlayShouldTurnOffSomethingAndCoverPan();
    }

    void StartVoiceOver6()
    {
        soundManager.PlayShouldTurnOffSomethingAndCoverPan();
    }
}
